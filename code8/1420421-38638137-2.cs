    results.GroupBy(p => p.GroupName)
                .Select(g => new FinalModel
                {
                    GroupName = g.Key,
                    Properties = g.ToDictionary(item => item.Key, item=> item.Value)
                });  
                      
