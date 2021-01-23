        var defaultItems= ConfigurationManager.GetSection("Default") as NameValueCollection;
        List<string> temp = new List<string>();
    
    if (defaultItems!= null)
    {
        foreach (var key in defaultItems.AllKeys)
        {
            string val= defaultItems.GetValues(key).FirstOrDefault();
            temp.Add(val);
        }
    }
    
        string[] arr = temp.ToArray();
