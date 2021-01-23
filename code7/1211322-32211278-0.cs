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
            [FindsBy(How = How.Id, Using = "lst-ib")]
            private IWebElement searchBox;
            [FindsBy(How = How.Name, Using = "btnG")]
            private IWebElement searchButton;
            private IWebDriver driver;
            public void search(String s)
            {
                searchBox.SendKeys(s);
                searchButton.Click();
            }
            public IWebElement getSearchBox()
            {
                return driver.FindElement(By.Id("lst-ib"));
            }
            public IWebElement getSearchButton()
            {
                return driver.FindElement(By.Name("btnG"));
            }
            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
            }
        }
    }
