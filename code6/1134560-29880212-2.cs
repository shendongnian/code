    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    
    namespace SeleniumTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (FirefoxDriver driver = new FirefoxDriver())
                {
                    driver.Navigate().GoToUrl("file://" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "test.html");
                    var bElements = driver.FindElementByXPath("//A").FindElements(By.TagName("b"));
                    //Use the line below if you don't care what TagName the child elements are
                    //var bElements = driver.FindElementByXPath("//A").FindElements(By.XPath(".//*"));
                    Console.WriteLine("Child elements: " + bElements.Count);
                }
            }
        }
    }
