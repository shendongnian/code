    var newDt = dt.AsEnumerable()
                  .GroupBy(r => r.Field<int>("Id"))
                  .Select(g =>
                  {
                      var row = dt.NewRow();
                      row["Id"] = g.Key;
                      row["Amount 1"] = g.Sum(r => r.Field<int>("Amount 1"));
                      row["Amount 2"] = g.Sum(r => r.Field<int>("Amount 2"));
                      row["Amount 3"] = g.Sum(r => r.Field<int>("Amount 3"));
                      return row;
                  }).CopyToDataTable();
