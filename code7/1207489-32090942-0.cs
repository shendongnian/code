    public string GetUserProperty(string propertyName, string defaultValue = "")
    {
        var propertyValue = SecurityUtil.GetUserProperty(propertyName);
        return Array.TrueForAll(propertyValue .ToCharArray(), c => Char.IsDigit(c)) ? propertyValue : defaultValue;
    }
