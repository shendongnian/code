    var list1 = (from t1 in dataTable1.AsEnumerable()
                    select new
                    {
                        Key1 = t1.Field<int>("Key1"),
                        Key2 = t1.Field<int>("Key2"),
                        A = t1.Field<string>("A"),
                        B = t1.Field<string>("B")
                    });
    
    var list2 = (from b in dataTable2.AsEnumerable()
                    select new
                    {
                        Key1 = b.Field<int>("Key1"),
                        Key2 = b.Field<int>("Key2"),
                        X = b.Field<string>("X"),
                        Y = b.Field<string>("Y")
                    });
    // Now join the 2 collections and get the result you want.
    var result = (from x in list1
                    join y in list2 on new { x.Key1,x.Key2} equals new { y.Key1,y.Key2 }
                    select new { A = x.A, X = y.X }).ToList();
