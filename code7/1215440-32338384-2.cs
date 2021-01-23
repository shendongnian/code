        foreach (var item in expando)
        {
            if (item.Value is ExpandoObject)
            {
                var store = item.Value as IDictionary<string, object>;
                if (!store.Keys.Contains("bizcardData")) // A Wierd hack to handle nested contacts. check properties are on first level
                {
                    store.TryGetValue("name", out name); 
                    store.TryGetValue("company", out company);
                    store.TryGetValue("designation", out designation);
                    store.TryGetValue("email", out email);
                    store.TryGetValue("phone", out phone);
                    cardDetails.Add(new SingleCardDetails
                    {
                        Name = Convert.ToString(name),
                        Company = Convert.ToString(company),
                        Email = Convert.ToString(email),
                        Designation = Convert.ToString(designation),
                        Phone = Convert.ToString(phone)
                    });
                }
                else // check second level where contact details are under bizcardData
                {
                    foreach (var level2 in item.Value as IDictionary<string, object>)
                    {
                        if (level2.Value is ExpandoObject)
                        {
                            var storeLevel2 = level2.Value as IDictionary<string, object>;
                            storeLevel2.TryGetValue("name", out name); // check properties are on first level
                            storeLevel2.TryGetValue("company", out company);
                            storeLevel2.TryGetValue("designation", out designation);
                            storeLevel2.TryGetValue("email", out email);
                            storeLevel2.TryGetValue("phone", out phone);
                        }
                    }
                }
            }
        }
