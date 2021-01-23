    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    namespace TestSelenium
    {
    [TestClass]
    public class UnitTest1
    {
        public ChromeDriver browser;
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                browser = new ChromeDriver();
                browser.Navigate().GoToUrl("https://roofandfloor.com/");
                System.Threading.Thread.Sleep(5000);
                // Select City.
                IWebElement parentDiv = browser.FindElement(By.ClassName("city-dropdown-search"));
                parentDiv.Click();
                this.SelectItem("Bangalore");
                // Select Property.
                parentDiv = browser.FindElement(By.ClassName("property-type-checkboxes"));
                parentDiv.Click();
                this.SelectItem("Villa");
                // Select Bed room. Need to write separate code for this.
                parentDiv = browser.FindElement(By.ClassName("bedroom-select-container"));
                parentDiv.Click();
                System.Threading.Thread.Sleep(1500);
                IWebElement items = browser.FindElement(By.ClassName("search-bedrooms"));
                foreach (IWebElement item in items.FindElements(By.TagName("span")))
                {
                    if (item.Text.Contains("1 BHK"))
                    {
                        item.Click();
                        break;
                    }
                } 
               
                // Select Max budget.
                parentDiv = browser.FindElement(By.Id("s2id_priceMax"));
                parentDiv.Click();
                this.SelectItem("5 Lakhs");
                // Select Build up area.
                parentDiv = browser.FindElement(By.Id("s2id_areaMin"));
                parentDiv.Click();
                this.SelectItem("600 Sq.ft.");
                // Select Possession.
                parentDiv = browser.FindElement(By.Id("s2id_possessionDate"));
                parentDiv.Click();
                this.SelectItem("Ready to Occupy");
            }
            catch
            { }
        }
        private void SelectItem(string itemText)
        {
            System.Threading.Thread.Sleep(1500);
            IWebElement items = browser.FindElement(By.Id("select2-drop")); 
            foreach (IWebElement item in items.FindElements(By.TagName("li")))
            {
                if (item.Text.Contains(itemText))
                {
                    item.Click();
                    break;
                }
            } 
        }
    }
