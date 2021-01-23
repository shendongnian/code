    public class MyWebDriver : IWebDriver
    {
        private IWebDriver webDriver;
        public string CurrentTest { get; set; }
        public MyWebDriver(IWebDriver webDriver)
        {
            this.webDriver = webDriver
        }
        
        public Method1()
        {
            webDriver.Method1();
        }
        public Method2()
        {
            webDriver.Method2();
        }
   
        ...
    }
