    public Guid? Icon 
    {
        get 
        {
            return (Guid?)ValidationHelper.GetGuid(GetValue("Icon"), Guid.Empty);
        }
        set 
        {
            SetValue("Icon", value.GetValueOrDefault());
        }
    }
