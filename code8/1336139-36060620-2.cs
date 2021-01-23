    public string ToJson(Dictionary<string, string> props)
    {
        IDictionary<string, object> json = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
        foreach (var prop in props)
        {
            string path = prop.Key;
            if (String.IsNullOrWhiteSpace(path)) continue;
            string[] keys = path.Split('.');
            
            string value = prop.Value;
            var cursor = json;
            for (int i = 0; i < keys.Length; i++)
            {
                object innerJson;
                if (!cursor.TryGetValue(keys[i], out innerJson))
                    cursor.Add(keys[i], new System.Dynamic.ExpandoObject() as IDictionary<string, object>);
                if (i == keys.Length - 1)
                    cursor[keys[i]] = value;
                cursor = cursor[keys[i]] as IDictionary<string, object>;
            }
        }
        return JsonConvert.SerializeObject(json);
    }
