    public static string TextEquals(string column, string value)
    {
        return string.Format(
            "<Eq><FieldRef Name='{0}' /><Value Type='Text'>{1}</Value></Eq>",
            column, value);
    }
