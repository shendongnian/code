    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using System;
    
    
    namespace SeleniumTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (FirefoxDriver driver = new FirefoxDriver())
                {
                    driver.Navigate().GoToUrl("file://" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "test.html");
                    //Use this line to capture all child "b" elements
                    var bElements = driver.FindElementByXPath("//A").FindElements(By.TagName("b"));
                    //Use the line below to capture all descendants
                    var bElements2 = driver.FindElementByXPath("//A").FindElements(By.XPath(".//*"));
                    //Use the line below to capture all immediate child elements
                    var bElements3 = driver.FindElementsByXPath("//A/*");
                    
                    Console.WriteLine("Child elements1: " + bElements.Count);
                    Console.WriteLine("Child elements2: " + bElements2.Count);
                    Console.WriteLine("Child elements3: " + bElements3.Count);
    
                    driver.Close();
                }
            }
        }
    }
