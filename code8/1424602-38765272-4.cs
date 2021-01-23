    // this is NOT a winform, this is a new and seperate class ...
    // don't try to mix this with an WinForm, that will fail
    public class BrowserTestRunner
    {
         // only this Test instances uses this browser
         Lapsoft_OneDriver browser;
         private void OpenBrowser(string username, string password)
         {
             browser = new Lapsoft_OneDriver(Browsers.Chrome);
             browser.GoToUrl(link);
             browser.FindElementById("txtUserName").SendKeys(username);
             browser.FindElementById("txtpassword").SendKeys(password);
             // you probably want to click on something here
         }
         // some other test
         private void ClickCart() 
         {
             browser.FindElementById("btnCart").Click();
         }
         // add other actions here
         // this starts the test for ONE browser
         public static void Start(string user, string pwd)
         {
             var runner = new BrowserTestRunner();
             runner.OpenBrowser(user, pwd);
             runner.ClickCart();
             // other actons here
         }
    }
