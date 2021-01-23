    var results = standardResults.DataTables[0]
                                 .AsEnumerable()
                                 .Select(item=>new 
                                 {
                                    Col1 = x.Field<string>("col1"),
                                    Col5 = x.Field<string>("col5")    
                                 });
