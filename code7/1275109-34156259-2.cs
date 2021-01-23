    [Test]
    public void Test1()
    {
        GetLoginAndPassword();
        driver.FindElement(By.Id("UserNameOrEmail")).SendKeys(loginName);
        driver.FindElement(By.Id("Password")).SendKeys(loginPassword);
    }
