    Dictionary<string, List<string>> obj = new Dictionary<string, List<string>>();
    
                List<string> keyValue = new List<string>();
                keyValue.Add("a");
                keyValue.Add("b");
                obj.Add("key1", keyValue);
    
                foreach (KeyValuePair<string, List<string>> entry in obj)
                {
                    // do something with entry.Value or entry.Key
                }
                List<string> keyValueOutput = new List<string>();
                if (obj.TryGetValue("key1",out keyValueOutput))
                {
                    foreach (string s in keyValueOutput)
                    {
                        // do something with entry.Value or entry.Key
                    }
                }
