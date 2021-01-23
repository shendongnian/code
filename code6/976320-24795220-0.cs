    string[] Student= playerpoints.AsEnumerable()
                      .GroupBy(r => new { Name = r.Field<string>("ID"), Action = r.Field<string>("Name") })
                      .Select(grp => new Student
                      {
                          AwardName = grp.Key.Action,
                          Count = grp.Count()
                      }).ToArray();
