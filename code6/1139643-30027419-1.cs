    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var arr = Enum.GetValues(_enumType);
        var exclude = new string[] { "None", "NONE", "Na", "NA"};
            
        return arr.Cast<object>().Where(e => !exclude.Contains(e.ToString())).ToList();
    }
