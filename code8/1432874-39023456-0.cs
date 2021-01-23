    `public bool IsValid
    {
        get { return (bool)base.GetValue(IsValidProperty); }
        set { base.SetValue(IsValidPropertyKey, value); }
    }
    public string ErrorMessage
    {
        get { return (string)base.GetValue(ErrorMessageProperty); }
        set { base.SetValue(ErrorMessageProperty, value); }
    }`
