    private static readonly string[] exclude =
        new string[] { "None", "NONE", "Na", "NA" };
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Enum.GetValues(_enumType).Cast<object>()
            .Where(e => !exclude.Contains(e.ToString())).ToList();
    }
