    var matched = from table1 in ds.Tables["Your Table"].AsEnumerable()
                  join table2 in dt2.AsEnumerable()
                  on table1.Field<string>("ColumnA") equals table2.Field<string>("ColumnC") 
                  where (table1.Field<string>("ColumnB").Equals(table2.Field<string>("ColumnA"))) 
                  || (table1.Field<int>("ColumnC") == table2.Field<int>("ColumnD")) 
                  select table1;
