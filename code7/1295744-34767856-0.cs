    public void waitroller()
    {
        Console.WriteLine("waiting roller");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromDays(2));
        IWebElement bannerElement = PropertiesCollection.driver.FindElement(By.Id("banner"));
        bool result = wait.Until((d) =>{ return bannerElement.Text.Contains("Rolling in 20.00"); });
       if(result)
       {
          return bannerElement;
       }
       else
       {
           return null;
       }
    }
