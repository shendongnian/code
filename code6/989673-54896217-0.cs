    using System;
    using System.Windows.Forms;
    
    namespace Browser_Test
    {
        public partial class myForm : Form
        {
            private bool linksOpenInSystemBrowser = false;
    
            public myForm()
            {
                InitializeComponent();
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                linksOpenInSystemBrowser = false;
                webBrowser1.Navigate(comboBox1.SelectedItem.ToString());
            }
    
            private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                if(!linksOpenInSystemBrowser)
                {
                    linksOpenInSystemBrowser = true;
                    return;
                }
    
                System.Diagnostics.Process.Start(e.Url.ToString());
    
                e.Cancel = true;
            }
        }
    }
