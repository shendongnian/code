    Regex regex = new Regex(...);
    JObject json = JObject.Parse(text);
    foreach (var property in json.GetProperties())
    {
        if (regex.IsMatch(property.Name))
        {
            ...
        }
    }
