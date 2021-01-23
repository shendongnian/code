    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private WebBrowser webBrowser;
            private TabControl tabControl1;
            private int i = 0;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                createBrowser();
            }
    
            private void createBrowser()
            {
                webBrowser = new WebBrowser();
                tabControl1 = new TabControl();
    
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.Location = new Point(0, 0);
                webBrowser.Dock = DockStyle.Fill;
                webBrowser.Visible = true;
                //webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                webBrowser.Navigate("http://bing.com");
                ///  webBrowser.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
                tabControl1.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
                tabControl1.TabPages.Add("New Tab");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(webBrowser);
                tabControl1.Size = new Size(500, 300);
                tabControl1.Location = new Point(0, 100);
                i += 1;
    
                this.Controls.Add(tabControl1);
            }
        }
    }
