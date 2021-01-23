    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.PageObjects;
    using System;
    namespace C_Sharp_Selenium_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                FirefoxDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://www.google.com");
                HomePage homePage = new HomePage(driver);
                PageFactory.InitElements(driver, homePage);
                homePage.search("stack overflow");
                homePage.getSearchBox().Clear();
                homePage.getSearchBox().SendKeys("c# pagefactory");
                homePage.getSearchButton().Click();
            }
        }
        public class HomePage
        {
            private By searchBox = By.Id("lst-ib");
            private By searchButton = By.Name("btnG");
            // add other elements in here that use FindsBy() to be loaded using PageFactory.InitElements()
            private IWebDriver driver;
            public void search(String s)
            {
                getSearchBox().SendKeys(s);
                getSearchButton().Click();
            }
            public IWebElement getSearchBox()
            {
                return driver.FindElement(searchBox);
            }
            public IWebElement getSearchButton()
            {
                return driver.FindElement(searchButton);
            }
            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
            }
        }
    }
