    using System;
    using System.Windows.Forms;
    
    namespace FacebookLiker
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //Go to that link
                webBrowser1.Url = new Uri("https://www.facebook.com/haadischool/?fref=ts");
    
            }
    
            private void btnLike_Click(object sender, EventArgs e)
            {
                //Scan the facebook page for a like button
    
                foreach(HtmlElement button in webBrowser1.Document.GetElementsByTagName("button"))
                {
                    //Is this the like button?
                    if (button.GetAttribute("className").Contains("PageLikeButton"))
                    {
                        //yes, simulate the click!
                        button.InvokeMember("click");
                    }
                }
            }
        }
    }
