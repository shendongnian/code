    [TestMethod]
    public void Login()
    {
        driver = new FirefoxDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(this.baseURL);
        driver
            .FindElementById("ctl00_ContentPlaceHolder1_Login1_UserName")
            .SendKeys("testuser");
        driver
            .FindElementById("ctl00_ContentPlaceHolder1_Login1_Password")
            .SendKeys("testpass");
        driver
            .FindElementById("ctl00_ContentPlaceHolder1_Login1_LoginButton")
            .Click();
    }
