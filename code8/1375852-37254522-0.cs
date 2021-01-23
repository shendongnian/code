      List<string> list = new List<string>();
                list.Add("A");
                list.Add("A");
                list.Add("B");
                var most = (from i in list
                            group i by i into grp
                            orderby grp.Count() descending
                            select new { grp.Key, Cnt = grp.Count() }).Where (r=>r.Cnt>1);
