    public string StateCode
    {
        get
        {
            return GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .First(f => f.FieldType == typeof (Statuses) && ToString() == f.GetValue(null).ToString())
                .Name;
        }
    }
