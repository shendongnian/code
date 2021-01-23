    [When("I click on (.*)")]
    public void WhenIClickOn(string buttonValue)
    {
        if(buttonValue=="Google Search")
        {
             _driver.FindElement(By.Id("gbqfba")).Click(); // Google - 'Google Search'
        }
        else if(buttonValue=="I'm feeling lucky")
        {
             _driver.FindElement(By.Id("gbqfsb")).Click(); // Google - 'Google Search'
        }
        else
        {
            throw new ArgumentOutOfRangeException(); 
        }
    }
