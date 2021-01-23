    [DataMember(Name="username")]
    public string Username
    {
        get { return this._Username; }
        set { SetField(ref _Username, value, "Username"); }
    }
