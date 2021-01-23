    Regex regex = new Regex(...);
    JObject json = JObject.Parse(text);
    foreach (var property in json.Properties())
    {
        if (regex.IsMatch(property.Name))
        {
            ...
        }
    }
