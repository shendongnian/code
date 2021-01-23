    var results = dt.AsEnumerable()
                .GroupBy(x => x.Field<int>("ParentID"))
                .Select(x => new
                        {
                           ParentID = x.Key,
                           DocumentName = x.Max(y => y.Field<int>("DocumentName")),
                           Count = x.Count()
                        }).ToList();
