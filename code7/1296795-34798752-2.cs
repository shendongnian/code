    public object Method(string key)
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
    int x = (int) Method(key);
    string word = (string) Method(key);
    bool isTrue = (bool) Method(key);
