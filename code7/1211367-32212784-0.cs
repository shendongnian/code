    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class MyBrowserFuncs
    {
        public WebBrowser WB;
        public MyBrowserFuncs(Form f)
        {
            WB = new WebBrowser();
            WB.Visible = false;
            f.Controls.Add(WB);
            WB.ObjectForScripting = this;
    
            WB.Navigate("mypage.html");
        }
        public string Test(string msg)
        {
            return WB.Document.InvokeScript
                                ("Test", new String[] { msg });
        }
    }
