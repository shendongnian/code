    var k = (from coa in db.MSTs
                           select new { S2 = coa.S2, S1 = coa.S1 }).ToList().
                           Select(x => new MST { S2 = x.S2, S1 = x.S1 }).ToList();
    
                    JArray Arrayone = new JArray(
                        k.Select(p => new JObject
                                    {
                                        { "Code", p.S1 },
                                        { "Name", p.S2 },
                                    })
                        );
    
                string jsonfile = JsonConvert.SerializeObject(Arrayone,Formatting.Indented);
                string path = @"C:\Users\Awais\Desktop\accounts.json";
                System.IO.File.WriteAllText(path, jsonfile);
