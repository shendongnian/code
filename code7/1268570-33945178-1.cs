    #region Custom Control Properties
    /// <summary>
    /// Gets or sets the Label which is displayed next to the field
    /// </summary>
    [Description("Size of the user image"), Category("Common Properties")]
    public Double PhotoSize
    {
        get { return (Double)GetValue(PhotoSizeProperty); }
        set { SetValue(PhotoSizeProperty, value); }
    }
    
    /// <summary>
    /// Gets or sets the Label which is displayed next to the field
    /// </summary>
    [Description("Username, split first and last names"), Category("Common Properties")]
    public String UserName
    {
        get { return (String)GetValue(UserNameProperty); }
        set { SetValue(UserNameProperty, value); }
    }
    public string[] SplitUsername
    {
        get { return GetValue(UserNameProperty).ToString().Split(' '); }
    }
    #endregion
