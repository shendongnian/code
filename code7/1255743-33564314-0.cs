    IEnumerable < object > query = (from a in db.Labels
                                    select new
                                    {
                                        Label = a.Title,
                                        Value = db.Values
                                                  .Where(w=>w.ID==a.ID)
                                                  .Count()
                                     }).ToList();
