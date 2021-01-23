            Dictionary<string, object> dict = new Dictionary<string, object>();
            Dictionary<string, int> innerdict = new Dictionary<string, int>();
            dict.Add("1", innerdict); // added to outer dictionary
            string key = "1";
            ((Dictionary<string, int>)dict[key]).Add("100", 100); // added to inner dictionary
