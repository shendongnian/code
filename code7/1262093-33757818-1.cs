    public static List<SelectListItem> GetEnumList(Type enumType)
    {
        return Enum.GetValues(enumType).Cast<IFormattable>().Select(v => new SelectListItem
        {
            Text = v.ToString(),
            Value = v.ToString("d", null)
        }).ToList();
    }
