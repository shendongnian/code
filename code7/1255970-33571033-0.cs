    var report = patients
                    .GroupBy(p => p.LivingSpace)
                        .Select(g => new
                        {
                            Unit = g.Key,
                            Count = g.Count()
                        })
                    .Union(patients
                        .Select(p => new
                        {
                            Unit = "Total",
                            Count = patients.Count
                        }));
