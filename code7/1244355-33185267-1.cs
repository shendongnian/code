            var input = JObject.Parse(File.ReadAllText("sample.json"));
            var rateDetails = (JArray)input["rateDetails"];
            var a = rateDetails
                        .Select(t => (JArray)t["allAdultFares"])
                        .Select(t => 
                            new Sellrate() 
                            { 
                              Singe = t[0].ToString().Split('-')[1].Replace(@"""", ""), 
                              Double = t[1].ToString().Split('-')[1].Replace(@"""", "") 
                            }).ToList();
