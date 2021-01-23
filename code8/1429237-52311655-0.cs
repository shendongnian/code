    public class RadioButtons
    {
        public RadioButtons(IWebDriver driver, ReadOnlyCollection<IWebElement> webElements)
        { 
            Driver = driver;
            WebElements = webElements;
        }
        protected IWebDriver Driver { get; }
        protected ReadOnlyCollection<IWebElement> WebElements { get; }
        public void SelectValue(String value)
        {
            WebElements.Single(we => we.GetAttribute("value") == value).Click();
        }
    }
