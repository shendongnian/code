    public void Click(string something)
    {
        if(driver.FindElement(By.Id(something)).Count > 0)
           driver.FindElement(By.Id(something)).Click();
        else if (driver.FindElement(By.Name(something)).Count > 0)
           driver.FindElement(By.Name(something)).Click();
    //and so on...
    }
