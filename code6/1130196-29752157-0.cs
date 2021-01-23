    public string StateCode
    {
        get
        {
            return GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof (ILLStatuses))
                .ToDictionary(f => f.Name, f => ((ILLStatuses) f.GetValue(null)).ToString())
                .First(dd => dd.Value == ToString())
                .Key;
        }
    }
