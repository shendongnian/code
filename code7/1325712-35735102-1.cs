<!-- -->
    string connectionString = (user passed in connection string)
    string query = @"SELECT t1.THISID AS ID, t1.SOMETHING1 AS Detail, t2.SOMETHING3 AS Objects
                     FROM Table1 AS t1
                     JOIN Table2 AS t2
                     ON t1.OTHERID = t2.OTHERID";
    using(DataContext dc = new DataContext(connectionString))
    {
        List<FlatRow> flat = dc.ExecuteQuery<FlatRow>(query);
        var aClasses = flat
                           .GroupBy(c => new { c.Id, c.Something1 })
                           .Select(c => new ClassA
                                        {
                                            ID = c.Key.Id,
                                            Detail = c.Key.Something1,
                                            Objects = c.Select(x => x.Something3).ToList()
                                        })
                           .ToList();
    }
