    public void EditUserAccount(string username)
    {
        Driver.FindElement(By.XPath("//table/tbody/tr[td[1] = '" + username + "']/td[4]/a[1]")).Click();
    }
    
    public void DeactivateUser(string username)
    {
        Driver.FindElement(By.XPath("//table/tbody/tr[td[1] = '" + username + "']/td[4]/a[2]")).Click();
    }
