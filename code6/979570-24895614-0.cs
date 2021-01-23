    public EmailEntryViewModel
    {
      private string _emailPrefix = string.Empty;
      public string FullEmailAddress
      {
        get
        {
          return _emailPrefix + "@gmail.com";
        }
        set
        {
          if (!value.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
          {
            //whatever logic that is internal
            throw new InvalidOperationException("Database contains an invalid email.");
          }
          this._emailPrefix = value.Substring(0,
            email.IndexOf("@gmail.com",  StringComparison.OrdinalIgnoreCase));
        }
      }
     [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*"]
      public string EmailPrefix
      {
        get 
        {
          return _emailPrefix;
        } 
        set 
        {
          _emailPrefix = value;
        } 
      }
    }
