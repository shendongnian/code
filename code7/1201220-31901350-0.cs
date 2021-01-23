    using System;
    using System.Windows.Forms;
    
    namespace TryCatch
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btn_Delete_Click(object sender, EventArgs e)
            {
                try
                {
                    if (textBox1.Text != "")
                    {
                        textBox1.Text = textBox1.Text = "";
                    }
                    else
                    {
                        throw new deleteData("Here we are having the custom exception do its own exception handling");
                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text = "Here we are catching the custom exception in a catch block\r\n\r\n";
                    textBox1.Text += "Exception details:" + ex.StackTrace.ToString();
                }
            }
    
            public class deleteData : Exception
            {
                public deleteData(string s)
                {
                    MessageBox.Show(s);
                }
            }
        }
    }
