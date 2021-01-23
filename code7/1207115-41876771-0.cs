    using OpenQA.Selenium;
    
    namespace Tests.Selenium.Utils
    {
        public static class DriverExtensions
        {
            public static IWebElement FindAdminMenu(this IWebDriver driver, string Id)
            {
                return driver.FindElement(By.CssSelector(
                    string.Format("[selenium-admin-menu='{0}']", Id)
                ));
            }
        }
    }
