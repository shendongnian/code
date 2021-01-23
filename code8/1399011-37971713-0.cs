    public string Email
    {
        set
        {
            _txtEmail.Click();
            Thread.Sleep(10);
            _txtEmail.SendKeys(value);
        }
    }
