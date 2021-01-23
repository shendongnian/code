    var res = db.Exposures
                .GroupBy(ex=>ex.ExpouserDate)
                .Select(gr=>
                {
                    Date = gr.Key;
                    DistinctIps = gr.Select(x=>x.UserIp).Distinct()
                });
