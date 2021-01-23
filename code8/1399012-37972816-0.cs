    public string Email
    {
        set
        {
            var selenium = new WebDriverBackedSelenium(driver, MyPageUrl);
            selenium.Start();
            selenium.Type("Email", value);
        }
    }
