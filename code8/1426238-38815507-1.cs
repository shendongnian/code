    var res = db.Exposures
                .GroupBy(ex=>ex.UserIp)
                .Select(gr=>
                {
                    UserIp = gr.Key;
                    DistinctIps = gr.Max(x=>x.ExpouserDate)
                });
