    public class Test
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
             var test = new Test();
             test.OpenBrowser(user, pwd);
             test.ClickCart();
             // other actons here
         }
    }
