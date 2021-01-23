    class MyWebDriver<T> where T : IWebDriver, new()
    {
        IWebDriver driver;
        private static string CurrentTest { get; set; }
    
        public MyWebDriver()
        {
            driver = new T();
        }
    
        public void Dispose()
        {
            this.driver.Dispose();
        }
    
        public IWebElement FindElement(By by)
        {
            return this.driver.FindElement(by);
        }
    
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return this.driver.FindElements(by);
        }
    
        public void Close()
        {
            this.driver.Close();
        }
    
        public void Quit()
        {
            this.driver.Quit();
        }
    
        public IOptions Manage()
        {
            return this.driver.Manage();
        }
    
        public INavigation Navigate()
        {
            return driver.Navigate();
        }
    
        public ITargetLocator SwitchTo()
        {
            return this.SwitchTo();
        }
    
        public string Url
        {
            get
            {
                return this.driver.Url;
            }
            set
            {
                this.driver.Url = value;
            }
        }
    
        public string Title
        {
            get
            {
                return this.driver.Title;
            }
        }
    
        public string PageSource
        {
            get
            {
                return this.driver.PageSource;
            }
        }
    
        public string CurrentWindowHandle
        {
            get
            {
                return this.driver.CurrentWindowHandle;
            }
        }
    
        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return this.WindowHandles;
            }
        }
    }
    
    public class MyTest
    {
        public void main()
        {
            MyWebDriver<FirefoxDriver> driver = new MyWebDriver<FirefoxDriver>();
            driver.Navigate().GoToUrl("www.google.com");
    
        }
    
    
    }
