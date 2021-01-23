    public Deposits(List<Dictionary<string, string>> LPQReq)
    {
        PropertyInfo[] properties = typeof(Deposits).GetProperties();
        foreach (Dictionary<string, string> PQList in LPQReq)
        {
            foreach (KeyValuePair<string, string> kvp in PQList)
            {
                if(properties.Any(x=>x.Name == kvp.Key) && 
                   properties[kvp.Key].PropertyType == typeof(string))
                {
                    properties[kvp.Key].SetValue(this, kvp.Value);
                    //                            ^ here we pass current instance
                }
            }
        }
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine("Name: " + property.Name + ", Value: " + 
                    property.GetValue(this));
            //                         ^ here we pass current instance
        }
    }
