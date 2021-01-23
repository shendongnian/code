    using System;
    using System.Collections.Generic;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support;
    using OpenQA.Selenium.PhantomJS;
    namespace PhantomJSExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string logFilePath = @"C:\Users\Username\Desktop\outputLog.log";
                IWebDriver driver = CreateInfolessPhantom(logFilePath);
            }
            // Prepares a PhantomJS driver that does not dislay its logs in the console window.
            // The trade-off is, you have to give it a file path to output to instead.
            static IWebDriver CreateInfolessPhantom(string logFilePath)
            {
                PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
                service.LogFile = logFilePath;
                return new PhantomJSDriver(service);
            }
        }
    }
