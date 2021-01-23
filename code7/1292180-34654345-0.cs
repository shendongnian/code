    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    
    try
    {
        wait.Until(ExpectedConditions.ElementIsVisible(by));
        isPresent = true;
    }
    catch (Exception) { }
