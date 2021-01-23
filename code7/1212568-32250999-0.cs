    var accountGroups = myDataTable.AsEnumerable()
                                   .GroupBy(x=>x.Field<string>("AccountName"))
                                   .Select(g => new Account {
                                        AccountName = g.Key,
                                        List = g.Select(g => g.Field<string>("ListItem").ToList()
                                    });
