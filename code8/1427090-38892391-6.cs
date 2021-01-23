    var matched = from table1 in ds.Tables["Your Table"].AsEnumerable()
                  join table2 in dt2.AsEnumerable()
                  on table1.Field<int>("ColumnA") equals table2.Field<int>("ColumnC") 
                  where (table1.Field<int>("ColumnB").Equals(table2.Field<int>("ColumnA"))) 
                  || (table1.Field<int>("ColumnC") == table2.Field<int>("ColumnD")) 
                  select table1;
