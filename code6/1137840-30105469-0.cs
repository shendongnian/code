    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.Events;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
        IWebDriver WebDriver = new FirefoxDriver();
        var firingDriver = new EventFiringWebDriver(WebDriver);
        firingDriver.ExceptionThrown += new EventHandler<WebDriverExceptionEventArgs>(firingDriver_ExceptionThrown);
    
    firingDriver.ElementClicked += new EventHandler<WebElementEventArgs>(firingDriver_ElementClicked);
     
    firingDriver.FindElementCompleted += new EventHandler<FindElementEventArgs>(firingDriver_FindElementCompleted);
    
      WebDriver = firingDriver;
    
    
    static void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
            {
             Console.WriteLine(e.ThrownException.Message);
            }
            
         static void firingDriver_FindElementCompleted(object sender, FindElementEventArgs e)
                {
                    Console.WriteLine(e.FindMethod);
                }
        
                static void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
                {
                    Console.WriteLine(e.Element);
                }
