    var t6 = firstTable.AsEnumerable()
                       .GroupBy(a => new {
                                         name = a.Field<string>("name"),
                                         date = a.Field<string>("date")
                                         }
                                )
                       .Select(g => g.First())
                       //or Select(g => g.OrderBy(a => a.Field<string>("clockIn")).First()
                       .ToList();
