    IWebDriver d;
    [TestInitialize]
    public void TestSetup()
    {
        d = new ChromeDriver("C:\\location\\of\\my\\chrome_driver\\is_here\\");
        d.Manage().Cookies.DeleteAllCookies();
        d.Manage().Window.Maximize();
    }
    [TestMethod]
    public void ClickTrumpet_LouieArmstrongMusicPlays()
    {            
        d.Navigate().GoToUrl("http://bupitybop.kom/");
        for (int i = 0; i < 12; i++)
        {
            d.FindElement(By.ClassName("boopi-boopi")).Click();
        }
        d.Quit();
    }
    
