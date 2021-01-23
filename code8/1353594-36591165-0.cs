    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Firefox;
    using System.Threading;
    
    // In This script TestInitialize & Test Cleanup executes for each TestMethod
    namespace Codify
    {
        [TestClass]
        public class UnitTest2{
        IWebDriver driver = new FirefoxDriver();
        
            [TestInitialize()]
                public void TestInitialize()
                {
                    driver.Navigate().GoToUrl("https://www.google.co.in");
                    Thread.Sleep(1000);
                }
    
            [TestMethod]
            public void TestMethod1()
            {
                ICollection<IWebElement> links = driver.FindElements(By.TagName("a"));
                foreach (var link in links)
                {
                    Console.WriteLine(link.GetAttribute("text"));
                }
            }
    
            [TestMethod]
            public void TestMethod2()
            {
                driver.FindElement(By.Id("lst-ib")).SendKeys("Testing");
                Thread.Sleep(1000);
                string str = driver.FindElement(By.XPath(".//*[@id='sbtc']/div[2]/div[2]/div[1]")).Text;
                Console.WriteLine(str.Length);
                string[] s = str.Split('\n');
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine(s[i]);
                }
            }
    
            [TestCleanup()]
            public void testcleanp()
            {
                driver.Quit();
            }
    
        }
    }
