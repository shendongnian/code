            var result = JObject.Parse(res);
            var description = (result["description"] as JObject);
            if (description != null)
            {
                var root = new RootObject
                {
                    code = (int)result["code"],
                    description = new NewCountryDescription
                    {
                        msg = description["msg"].ToString(),
                        Countries = (from prop in description.Properties()
                                     where prop.Name != "msg"
                                     select new NewCountry
                                     {
                                         id = prop.Value["id"].ToString(),
                                         name = prop.Value["name"].ToString()
                                     }).ToList()
                    }
                };
                Console.Write(root);
            }
