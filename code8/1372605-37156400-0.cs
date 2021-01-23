    var t6 = firstTable.AsEnumerable()
                       .GroupBy(m => new {
                                         a.Field<string>("name"),
                                         a.Field<string>("date")
                                         }
                                )
                       .Select(g => g.First())
                       //or Select(g => g.OrderBy(a => a.Field<string>("clockIn")).First()
                       .ToList();
