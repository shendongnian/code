    public string GetUserProperty(string propertyName, string defaultValue = "")
    {
        var propertyValue = SecurityUtil.GetUserProperty(propertyName); // Why used var maybe because its not convertible to integer?
        return !string.IsNullOrWhiteSpace(propertyValue) ? propertyValue : defaultValue; // If this is true and propertyValue is not convertible to Int32, System.FormateException will be occurred.
    }
