    public class TestBase
    {
        IWebDriver driver;
        public TestBase()
        {
           driver = new FirefoxDriver();
           driver.Navigate().GoToUrl("example.com);
           driver.Manage().Window.Maximize();
        }
        public void Login()
        {       
           IWebElement email = driver.FindElement(By.Id("Email"));
           email.SendKeys("abc@xyz.com");
           IWebElement password = driver.FindElement(By.Id("Password"));
           password.SendKeys("abcdef");
           System.Threading.Thread.Sleep(500);
           IWebElement login = driver.FindElement(By.XPath("//button[contains(.,'LogIn')]"));
           login.Submit();
           System.Threading.Thread.Sleep(500);
        }
    }
    [TestClass]
    public class LoginTests : TestBase
    {
        [TestInitialize]
        public void MyTestInit()
        {
            Login();
        }
        [TestCleanup]
        public void MyTestCleanUp()
        {
            LogOut(); // Implement log out functionality.
        }
       
        [TestMethod]
        public void LoginTestOne()
        {    
           // test method logic here.
        }
    }
