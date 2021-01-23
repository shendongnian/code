        var rowsgroups =  from row in store_temp.GroupBy(row =>row.Field<string>("executiondate"))
                          .OrderBy((g=> g.OrderByDescending(y=>y.Field<string>("executiondate")).ThenByDescending(y=> y.Field<string>("rf"))))
                          .AsEnumerable()//and please try .AsEnumerable() here
                          .Select((n,index) => 
                          new {
                                index,
                                patn = n.ElementAt(0).ToString(),
                                rf = n.ElementAt(1).ToString(),
                                rf_num = i+1,
                                name = n.ElementAt(2).ToString() ,
                                conv = n.ElementAt(3).ToString(),
                                conv_type = n.ElementAt(4).ToString(),
                                recorddate = n.ElementAt(5).ToString(),
                                executiondate = n.ElementAt(6).ToString() 
    
                           }).ToArray();
