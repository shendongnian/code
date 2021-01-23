    private static string GetValue(object dictionary, object key)
    {
        PropertyInfo itemProperty = dictionary.GetType().GetProperty("Item");
        return itemProperty.GetValue(dictionary, new object[] { key }).ToString();
    }
