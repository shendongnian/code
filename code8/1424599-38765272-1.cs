    public class Test
    {
         // only this Test instances uses this browser
         Lapsoft_OneDriver browser;
         public void OpenBrowser(string username, string password)
         {
             browser = new Lapsoft_OneDriver(Browsers.Chrome);
             browser.GoToUrl(link);
             browser.FindElementById("txtUserName").SendKeys(username);
             browser.FindElementById("txtpassword").SendKeys(password);
         }
         public void ClickCart() 
         {
             browser.FindElementById("btnCart").Click();
         }
         // this starts the test for ONE browser
         public static Test Start(string user, string pwd)
         {
             var test = new Test();
             test.OpenBrowser(user, pwd);
             test.ClickCart();
             return test;
         }
    }
