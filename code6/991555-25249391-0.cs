    public void GoToProductSelection(string choice)
    {
        try
        {
            this.GoToFacilitySelection();
            IWebElement productsDdl = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("ctl00_ContentPlaceHolder1_ddlProducts")));
            SelectElement options = new SelectElement(productsDdl);
            options.SelectByText(choice);
            IWebElement product = options.SelectedOption;
            IWebElement contBtn;
            IWebElement selCheckBox; 
            string val = (product.GetAttribute("value"));
            IWebElement addToOrderBtn = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnAddItem"));
            addToOrderBtn.Click();
        }
        catch (NoAlertPresentException)
        {
            //code to handle NoAlertPresentException
        }
    }
