    class callingfunction
    {
        public static IWebDriver driver = null;
    
        public void function1()
        {
            for (int i = 0; i < 10; i++)
            {
               driver = new ChromeDriver(Cpath); // launch browser
               driver.Navigate().GoToUrl("http://www.aaa.org");
               driver.Navigate().GoToUrl("http://www.aaa.org/contactus");
               driver.FindElement(By.Name("contact")).SendKeys(contact);
               driver.Navigate().GoToUrl("http://www.aaa.org/aboutus");
               //Code logic 
    
               driver.Close(); // close browser
            }
            driver.Quit(); // close browser driver
        }
    }
