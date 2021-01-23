    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Interactions;
    namespace MyFirstAutoScript
    {
     class Program
      {
        static void Main(string[] args)
        {
           IWebDriver driver = new FirefoxDriver();
           driver.Navigate().GoToUrl("https://yelitzascareerjourney.wordpress.com/");
           new Actions(driver).MoveToElement(driver.FindElement(By.LinkText("About Me"))).Click().Build().Perform();
           driver.FindElement(By.LinkText("My Resume")).Click(); //my page brakes here
           more commands go here...
           }
        }
    }
