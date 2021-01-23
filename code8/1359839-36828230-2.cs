    [ConfigurationProperty("", IsDefaultCollection = true)]
    [ConfigurationCollection(typeof (SystemEmailsElementCollection),
        AddItemName = "email")]
    public SystemEmailsElementCollection Emails
    {
        get { return base[""] as SystemEmailsElementCollection; }
    }
