    public string GetImagePath(object value)
    {
        if (string.IsNullOrEmpty(Convert.ToString(value))) return string.Empty;
        var x = int.Parse(value.ToString());
        return x > 0 ? "Your Image Path" : "Default Image Path";
    }
