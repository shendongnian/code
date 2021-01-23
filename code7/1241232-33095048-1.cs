    do
    {
    IList<IWebElement> Test= SeleniumDriver.WebDriver.FindElements(By.Xpath(""));
    
    //HERE YOU CHECK IF BUTTON EXIST
    if(isElementPresented(By.Id("")))
    {
    driver.FindElement(By.Id("")).Click;
    }
    else
    {
    //if button not exists
    buttonExist = false;
    }
    }while(buttonExist);
