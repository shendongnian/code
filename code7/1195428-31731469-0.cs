    public static void clickElementAsUser(WebDriver driver, By by)
    {
        WebElement element;
    
        try
        {
            element = driver.findElement(by);
            scrollElementIntoView(driver, element);
            Thread.sleep(100); //Wait a moment for the element to be scrolled into view
            element.click();
        }
        catch(Exception e) //Could be broken into multicatch
        { 
            //Do Something
        }
    }
    
    public static void scrollElementIntoView(WebDriver driver, WebElement element)
    {
        try
        {
            ((JavascriptExecutor)driver).executeScript("arguments[0].scrollIntoView(true);", element);
        }
        catch(Exception e)
        {
            //Do Something
        }
    }
