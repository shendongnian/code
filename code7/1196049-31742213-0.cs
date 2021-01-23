    private static void LogInAsUser()
    {
            Driver.FindElement(By.XPath("//a[contains(@href, '#login-window')]")).Click();
            Driver.FindElement(By.XPath("//input[contains(@id, 'UserName')]" )).SendKeys("exampleuser@exampleemail.com");
            Driver.FindElement(By.XPath("//input[contains(@id, 'Password')]")).SendKeys("example");
            Driver.FindElement(By.Id("btnLogin")).Click();
            {
            Result.Pass(60);
            }
    }
