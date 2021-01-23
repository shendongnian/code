    public Deposits(Dictionary<string, string> PQList)
    {
        PropertyInfo[] properties = typeof(Deposits).GetProperties();
        foreach (KeyValuePair<string, string> kvp in PQList)
        {
             if(properties.Any(x=>x.Name == kvp.Key) && 
                properties[kvp.Key].PropertyType == typeof(string))
             {
                 properties[kvp.Key].SetValue(this, kvp.Value);
             }
        }
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine("Name: " + property.Name + ", Value: " + 
                    property.GetValue(this));
        }
    }
