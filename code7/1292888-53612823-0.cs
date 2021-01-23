        public WebDriverActionListener(IWebDriver _driver): base(_driver)
        {
            this._driver = _driver;
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
        }
        protected override void OnElementClicking(WebElementEventArgs e)
        {
            _driver.Sync();
            string type = getTypeofElement(e.Element.TagName);
            base.OnElementClicking(e);
            Reporter.Logtofile("Clicked on element:" +e.Element.Text + " of type:" + type,Status.Info);
            _driver.Sync();
        }
}
