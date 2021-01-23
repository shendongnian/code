    public dynamic Method(string key)
    {
        if(dictionary.ContainsKey(ID)
        {
            Var temp = dictionary[ID];
    
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
