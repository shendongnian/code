    var result = myItems.Select(item => 
                    {
                        var record = new ParentRecord
                        {
                            ParentID = item.ParentID,
                            Name = item.Name,
                            Age = item.Age
                        };
                        record.MyNestedChildRecords.AddRange(item.MyNestChildRecords);
                        return record;
                    }).ToList()
