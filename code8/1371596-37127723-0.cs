    IWebElement elem =
      new WebDriverWait(Driver,
                        TimeSpan.FromSeconds(30), // time out
                        TimeSpan.FromMilliseconds(250)) // polling interval
        .Until(ExpectedConditions.ElementExists(By.ClassName("abc"));
