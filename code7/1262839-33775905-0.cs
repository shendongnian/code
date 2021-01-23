    IEnumerable<ClassName> = from table1 in connection.Get<DbTable1>
                             join table2 in connection.Get<DbTable2>
                             on table1.A equals table2.A
                             select new ClassName
                             {
                                 // Set the values for your properties here
                             };
