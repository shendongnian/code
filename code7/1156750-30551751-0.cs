         using Login_Elements;
         using Dashboard;
    
        namespace Test_Dashboard_Elements
        {
            [TestClass]
            public class DashboardTests
            {
               IWebDriver _driver;
               DashboardElements dash;
    
            [TestInitialize]
            public void Test_Setup()
            {
              _driver = new FirefoxDriver();
    		   dash = new DashboardElements(_driver);
               LoginPage login = new LoginPage(_driver);
               _driver.Navigate().GoToUrl("exampleurl/login");
               login.Login();
            }
        }  
