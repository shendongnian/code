    static void Apply(IDictionary<string, string> properties, string input)
    {
        // split by semicolon
        var props = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        // add/merge each key-value pair into the dictionary
        foreach (var t in props)
        {
            var tokens = t.Trim().Split('=');
            var key = tokens[0];
            var value = tokens[1];
            // this will add a new value, or update the existing one
            properties[key] = value;
        }
    }
