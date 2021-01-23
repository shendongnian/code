        static void Apply(IDictionary<string, object> dict, string key, Action<string> setter)
        {
            if (!dict.ContainsKey(key) || string.IsNullOrEmpty(dict[key].ToString()))
                return;
            setter(dict[key].ToString());
        }
