    var results1 = (from t in DB.Table
                    group t by new { t.OrderN, t.Name } into grp
                    select new
                    {
                        OrderN = grp.Key.OrderN,
                        Name = grp.Key.Name,
                        FirstDate = grp.FirstOrDefault().Date
                    }).ToList();
