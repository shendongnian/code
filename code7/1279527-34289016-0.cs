    string json = JsonConvert.SerializeObject(collection.Select(innerList => 
                  innerList.Select(type => new Dictionary<string,object>()
                  {
                       {
                            type.Type, type.Value
                       }
                  })));
