    public string MyProperty
    {
        get { return base.Get<string>(); } // same as calling Get<string>("MyProperty")
        set { base.Set<string>(value); } // same as calling Set<string>(value, "MyProperty")
    }
