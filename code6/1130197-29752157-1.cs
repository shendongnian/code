    public string StateCode
    {
        get
        {
            return GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof (Statuses))
                .ToDictionary(f => f.Name, f => ((Statuses) f.GetValue(null)).ToString())
                .First(dd => dd.Value == ToString())
                .Key;
        }
    }
