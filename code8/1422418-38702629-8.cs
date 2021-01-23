    public string Value
    {
        get
        {
            if (MyField != null)
                return MyField.Value;
            return null;
        }
        set
        {
            if (MyField != null)
                MyField.Value = value;
        }
    }
