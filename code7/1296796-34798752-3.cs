    public dynamic Method(string key)
    {
        if(dictionary.ContainsKey(key))
        {
            var temp = dictionary[key];
    
            switch (temp.Type)
            {
                case "bool":
                    return Convert.ToBoolean(temp.Value);
    
                case "int"
                    return Convert.ToInt(temp.Value);
    
                case "string"
                    return temp.Value;
            }
        }
    
        return "NULL"; 
    }
    ...
    int x = Method(key);
    string word = Method(key);
    bool isTrue = Method(key);
