    public static List<SelectListItem> GetEnumList<TEnum>()
        where TEnum : struct, IConvertible, IFormattable
    {
        return ((TEnum[])Enum.GetValues(typeof(TEnum))).Select(v => new SelectListItem
        {
            Text = v.ToString(),
            Value = v.ToString("d", null)
        }).ToList();
    }
