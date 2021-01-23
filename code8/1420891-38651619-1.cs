    var result = from g in (from d in data
                     group d by (int)(d.When.TotalSeconds / 30))
                 let c = g.Count()
                 select new TimeValues(TimeSpan.FromSeconds(g.Key * 30),
                    g.Aggregate(new float[g.First().Values.Length],
                        (a, tv) =>
                        {
                            for (int i = 0; i < a.Length; i++)
                            {
                                a[i] += tv.Values[i];
                            }
                            return a;
                        },
                        a =>
                        {
                            for (int i = 0; i < a.Length; i++)
                            {
                                a[i] /= c;
                            }
                            return a;
                        }));
