    var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                Dictionary<string, string> temp = new Dictionary<string, string>();
                Parallel.ForEach(obj, (item)=> {
                    temp.Add(item.Value, item.Key);
                });
