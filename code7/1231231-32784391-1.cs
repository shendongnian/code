    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Chrome;
    
    
    namespace WEBDRIVER
    {
      class Program
      {
        static void Main(string[] args)
        {
          IWebDriver driver = new ChromeDriver();
          driver.Navigate().GoToUrl("http://www.google.com/");
          IWebElement query = driver.FindElement(By.Name("q"));
          query.SendKeys("banana");
          query.Submit();
    
          WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
          wait.Until((d) => { return d.Title.ToLower().StartsWith("banana"); });
    
          System.Console.WriteLine("Page title is: " + driver.Title);
          driver.Quit();
        }
      }
    }
