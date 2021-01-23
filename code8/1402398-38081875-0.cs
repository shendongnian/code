    public void FindStuff()
    {
        var stuff = driver.FindElements(By.Name("role"));
        stuff[2].Click();
    }
