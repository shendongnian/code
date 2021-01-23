    public string UserName
    {
        get { return _username; }
        set
        {
            // Make sure new value is valid (not null/empty, exists, etc.)
            if (string.IsNullOrEmpty(value))
                // Do something (throw exception, show error, etc.)
            else
            {
                _userName = value;
                SetupDropDownList();
            }
        }
    }
    private string _userName;
