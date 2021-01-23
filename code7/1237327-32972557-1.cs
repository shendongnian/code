    Dictionary<string, string> placeholders = new Dictionary<string, string>
    {
        { "#{APPDATA}", @"C:\Users\Simon\AppData\Roaming" },
        { "#{SYSTEM32}", @"C:\Windows\System32" }
    };
    string ReplacePlaceholders (string text)
    {
        foreach (var kv in placeholders)
        {
            text = text.Replace(kv.Key, kv.Value);
        }
        return text;
    }
