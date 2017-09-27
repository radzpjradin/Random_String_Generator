using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x1
{
    public partial class Form1 : Form
    {
        bool nonNumberEntered = true;
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            StringGen.stringc str = new StringGen.stringc();
            if (textBox2.Text.Length != 0)
            {
                int a = Int32.Parse(textBox2.Text);
                if (radioButton1.Checked)
                    textBox1.Text = str.AlphaNumeric(a);
                else if (radioButton2.Checked)
                    textBox1.Text = str.Numeric(a);
                else if (radioButton3.Checked)
                    textBox1.Text = str.Alphabet(a);
                else
                    textBox1.Text = "Please Choose a type of Password";
            }
            else
                textBox1.Text = "Please Type the Length Value";

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

namespace StringGen
{
    public class stringc
    {
        public string AlphaNumeric(int len)
        {
            Random r = new Random();
            int l = 0;
            string a = null;
            while(l < len)
            {
                int asc = r.Next() % 100;
                if (asc > -1 && asc < 26)
                {
                    int decision = r.Next() % 3;
                    if (decision == 0)
                    {
                        int base0 = 65;
                        base0 += asc;
                        char i = (char)base0;
                        a += i.ToString();
                        l++;
                    }
                    else if (decision == 1)
                    {
                        int base0 = 97;
                        base0 += asc;
                        char i = (char)base0;
                        a += i.ToString();
                        l++;
                    }
                    else
                    {
                        int x = r.Next() % 10;
                        a += x.ToString();
                        l++;
                    }
                }
                else
                    asc = r.Next() % 100;
            }
            return a;
        }
        public string Numeric(int len)
        {
            Random r = new Random();
            int l = 0;
            string a = null;
            while(l < len)
            {
                int x = r.Next() % 10;
                a += x.ToString();
                l++;
            }
            return a;
        }
        public string AlphaCap(int len)
        {

            string a = null;
            Random r = new Random();
            int l = 0;
            while(l < len)
            {
                int asc = r.Next() % 100;
                if (asc > -1 && asc < 26)
                {
                    int base0 = 65;
                    base0 += asc;
                    char i = (char)base0;
                    a += i.ToString();
                    l++;
                }
                else
                    asc = r.Next() % 100;
            }
            return a;
        }
        public string AlphaSmall(int len)
        {

            string a = null;
            Random r = new Random();
            int l = 0;
            while (l < len)
            {
                int asc = r.Next() % 100;
                if (asc > -1 && asc < 26)
                {
                    int base0 = 97;
                    base0 += asc;
                    char i = (char)base0;
                    a += i.ToString();
                    l++;
                }
                else
                    asc = r.Next() % 100;
            }
            return a;
        }
        public string Alphabet(int len)
        {
            string a = null;
            Random r = new Random();
            int l = 0;
            while(l < len)
            {
                int asc = r.Next() % 100;
                if (asc > -1 && asc < 26)
                {
                    int decision = r.Next() % 2;
                    if (decision == 0)
                    {
                        int base0 = 97;
                        base0 += asc;
                        char i = (char)base0;
                        a += i.ToString();
                        l++;
                    }
                    else
                    {
                        int base0 = 65;
                        base0 += asc;
                        char i = (char)base0;
                        a += i.ToString();
                        l++;
                    }
                }
                else
                    asc = r.Next() % 100;
            }
            return a;
        }
    }
}