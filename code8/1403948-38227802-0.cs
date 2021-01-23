    public Dictionary<string, string> GetTotalResourceSet(CultureInfo culture)
        {
            Dictionary<string, string> set;
            if (_resources.TryGetValue(culture.Name, out set))
                return set;
            var wl = getWhitelabelResourceSet(culture);
            var loc = getLocalResourceSet(culture);
            var dict = loc.Cast<DictionaryEntry>()
               .ToDictionary(x => { return x.Key.ToString(); }, x =>
               {
                   if (x.Value.GetType() == typeof(string))
                       return x.Value.ToString();
                   return "";
               });
            if (wl != null)
            {
                var wlDict = wl.Cast<DictionaryEntry>()
                   .ToDictionary(x => { return x.Key.ToString(); }, x =>
                   {
                       if (x.Value.GetType() == typeof(string))
                           return x.Value.ToString();
                       return "";
                   });
                set = wlDict.Concat(dict.Where(kvp => !wlDict.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            else
            {
                set = dict;
            }
            if (set != null)
            {
                _resources.TryAdd(culture.Name, set);
            }
            return set;
        }
