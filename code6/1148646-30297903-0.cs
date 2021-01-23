    Dictionary<string, string> d = new Dictionary<string, string>();
                string keyvalue;
                if (d.ContainsKey("value to find"))
                {
                    if (d.TryGetValue("value to find", out keyvalue))
                    {
                        //// here keyvalue variable has the value 
                    }
                    else
                    {
                        ///value is null or throws exception
                    }
                }
                else
                {
                        ////key no exists
                }
