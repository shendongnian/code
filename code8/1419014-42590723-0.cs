    class LoginPageObject
        {
            public LoginPageObject()
            {
                PageFactory.InitElements(TestBase.driver, this);
            }
    
            [FindsBy(How = How.Id, Using = "UserName")]
            public IWebElement TxtUsername { get; set; }
    
            [FindsBy(How = How.Id, Using = "Password")]
            public IWebElement TxtPassword { get; set; }
    
            [FindsBy(How = How.Id, Using = "submit")]
            public IWebElement BtnLogin { get; set; }
        }
