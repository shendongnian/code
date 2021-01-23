    Dictionary<string, string> items = new Dictionary<string, string>();
    foreach (string key in ConfigurationManager.AppSettings) {
        string value = ConfigurationManager.AppSettings[key];
        items.Add(key, value);
    }
    string json = JsonConvert.SerializeObject(items, Formatting.Indented);
