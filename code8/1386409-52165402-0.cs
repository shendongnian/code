                      dt = dt.AsEnumerable()
                        .GroupBy(r => r["fldReportCode"])
                        .Select(g =>
                         {
                            var row = dt.NewRow();
                          row["fldReportCode"] = g.Key;
                          row[15] = g.Sum(r => (decimal)r[15]);
                          //row["Amount 2"] = g.Sum(r => r.Field<int>("Amount 2"));
                          //row["Amount 3"] = g.Sum(r => r.Field<int>("Amount 3"));
                              return row;
                          }).CopyToDataTable();
