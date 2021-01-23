    public static List<SelectListItem> GetEnumList<TEnum>(TEnum value) where TEnum : IConvertible
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => new SelectListItem
        {
            Text = v.ToString(),
            Value = v.ToInt32(null).ToString()
        }).ToList();
    }
