    private static void LogInAsUser()
    {
            Driver.FindElement(By.XPath("//a[contains(@href, '#login-window')]")).Click();
            IWebElement username = Driver.FindElement(By.XPath("//input[contains(@id, 'UserName')]" ));
            IWebElement password = Driver.FindElement(By.XPath("//input[contains(@id, 'Password')]"));
            username.Clear();
            username.SendKeys("exampleuser@exampleemail.com");
            password.Clear();
            password.SendKeys("example");
            Driver.FindElement(By.Id("btnLogin")).Click();
            {
                Result.Pass(60);
            }
    }
