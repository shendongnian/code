    using System;
       using System.Collections.Generic;
       using System.ComponentModel;
       using System.Data;
       using System.Drawing;
       using System.Text;
       using System.Windows.Forms;
       namespace Notepad
         {
            public partial class Find : Form
              {
               int k = 0;
        string text;
        static int curr = 0;
        public Find()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // string[] k;
          //  k[0] = Form1.textBox1.Lines.GetValue(0);
            if (Form1.textBox1.Text == "")
            {
                MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
            }
            else
            {
                text = StoreData.getAllText();
                if (radioButton2.Checked == true)
                {
                    for (int i = curr; i <= text.Length; i++)
                    {
                        if (curr + textBox1.Text.Length <= text.Length)
                        {
                            if (string.Compare(text.Substring(curr, textBox1.Text.Length), textBox1.Text, true)==0)
                            {
                                Form1.textBox1.Select(curr, textBox1.Text.Length);
                                curr++;
                                break;
                            }
                            else
                            {
                                curr++;
                                if (curr == text.Length)
                                {
                                    MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
                                }
                            }
                        }
                    }
                }
                else
                {
                    // k to able the current continuted not in the start
                    if (k == 0)
                    {
                        k = 1;
                        curr = text.Length - textBox1.Text.Length;
                        StoreData.setCurrent(curr);
                    }
                    for (int i = StoreData.getCurrent(); i >= 0; i--)
                    {
                        // if (curr <= 0)
                        //{
                        if (string.Compare(text.Substring(curr, textBox1.Text.Length), textBox1.Text,true)==0)
                        {
                            Form1.textBox1.Select(curr, 1);
                           // Form1.textBox1.Find(textBox1.Text, curr, Form1.textBox1.TextLength, RichTextBoxFinds.None);
                            curr--;
                            StoreData.setCurrent(curr);
                            break;
                        }
                        else
                        {
                            curr--;
                            if (curr == 0)
                            {
                                MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
                            }
                        }
                        // }
                        StoreData.setCurrent(curr);
                    }
                }
                text = Form1.textBox1.Text;
                StoreData.setAllText(Form1.textBox1.Text);
                Form1.textBox1.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                curr = 0;
                k = 0;
                button1.Enabled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
