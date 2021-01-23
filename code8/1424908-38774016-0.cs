     var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    
    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ID("id of loading element ")));
    //Now go to find username element 
    var userName = wait.Until(ExpectedConditions.ElementIsVisible(By.ID("UserName")));
    userName.SendKeys("username");
