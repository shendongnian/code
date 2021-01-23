    from p in myDataTable.AsEnumerable
    group p by p.Field<string>("Emp") into g
    select new { Emp = g.Key, 
                 Data = g.Select(gg=>new EmpClass 
                                      { 
                                         LastName = gg.Field<string>("lName")
                                      }
                                 )
               }
