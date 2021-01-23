    using System.Diagnostics;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                linkLabel.Text = "Click to search!";
                linkLabel.LinkClicked += LinkLabel_LinkClicked;
            }
            private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                string googleSearch = @"https://www.google.com/?q=";
                Process.Start(googleSearch + textBox.Text);
            }
        }
    }
