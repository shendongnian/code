    [FindsBy(How = How.Id, Using = "searchButton")]
    public IWebElement btnSearch { get; set; }
    public void SelectOperator(String name, String establishmentNumber)
    {
        this.txtName.SetInputField(name);
        this.txtEstablishmentNumber.SetInputField(establishmentNumber);                
        new WebDriverWait(SeleniumTests.driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(this.btnSearch))
            .Click();
    }
