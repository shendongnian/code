    var matched = from table1 in ds.Tables["Your Table"].AsEnumerable()
                  join table2 in dt2.AsEnumerable()
                  on table1.Field<int>("ColumnA") equals table2.Field<int>("ColumnA") 
                  where (table1.Field<int>("ColumnB") == table2.Field<int>("ColumnB")) 
                  || (table1.Field<string>("ColumnC").Equals(table2.Field<string>("ColumnC"))) 
                  || (table1.Field<object>("ColumnD") == table2.Field<object>("ColumnD"))
                  select table1;
