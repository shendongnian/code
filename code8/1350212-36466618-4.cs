           var converter = new ExpandoObjectConverter();
            var deserializeObject = JsonConvert.DeserializeObject<JObject>(jsonString, converter);
            foreach(var v in deserializeObject["Model"])
            {
                if(v["Table"] != null && v["Table"].Type == JTokenType.Object)
                {
                    foreach (var x in v["Table"]["Row"])
                    {
                        Console.Write(x["BookId"] + " : " + x["BookName"] + Environment.NewLine);
                    }
                }
                else if (v["Table"].Type == JTokenType.Array)
                {
                    foreach(var subTable in v["Table"])
                    {
                        foreach (var row in subTable["Row"])
                        {
                            Console.Write(row["BookId"] + " : " + row["BookName"] + Environment.NewLine);
                        }
                    }
                    
                }              
            }
