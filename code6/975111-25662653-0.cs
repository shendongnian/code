      using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.IO;
        using System.Reflection;
        using OpenQA.Selenium;
        using OpenQA.Selenium.Remote;
        using NUnit.Framework;
        using OpenQA.Selenium.Interactions;
        using System.Threading;
        using OpenQA.Selenium.Appium;
        using OpenQA.Selenium.Appium.MultiTouch;
        using OpenQA.Selenium.Appium.Interfaces;
        using System.Drawing;
        
        namespace ClassLibrary2
        {
            [TestFixture]
            public class Class1
            {
                public AppiumDriver driver;
                public DesiredCapabilities capabilities; 
        
                public Class1()
                {
                    Console.WriteLine("Connecting to Appium server");
                    capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(CapabilityType.BrowserName, "Android");
                    capabilities.SetCapability(CapabilityType.Platform, "Windows");
                    capabilities.SetCapability(CapabilityType.Version ,"4.1.2");
                    capabilities.SetCapability("Device", "Android");
                    
                    //Application path and configurations
          
                   driver = new AppiumDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
                }
    
    
            [Test]
            public void login()
            {
    
                driver.FindElement(By.Name("Country")).Click();
                //Your further code as per the application.
               
               
        
            }
