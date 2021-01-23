            public static Dictionary<String, String> dict = new Dictionary<String, String>();
            
             public void dictionaryadd(String key, String value) 
        {
          dict.Add(key, value);
          }
          static List<int> GetKeysFromValue(Dictionary<string, string> dict, string value)
    {
        // Use LINQ to do a reverse dictionary lookup.
        // Returns a 'List<T>' to account for the possibility
        // of duplicate values.
        return
            (from item in dict
             where item.Value.Equals(value)
             select item.Key).ToList();
    }
           public String dictionaryout(String key)
        {
            string value;
            if(dict.TryGetValue(key,out value))
                    return value; 
            else    return String.Empty;
         }
         
         }
