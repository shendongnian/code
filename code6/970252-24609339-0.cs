     var query = (from callLog in callLogs
                             group callLog by callLog.Number into g
                             select new
                             {
                                 who = contacts.Where(c => c.Phone == g.Key),
                                 how_much = g.Count()
                             }).GroupBy(c=>c.how_much);
         foreach (var q in query)
                    {
                        Console.WriteLine(q.Key + " " + q.Count());
                        foreach (var qq in q)
                        {
                            foreach (var qqq in qq.who)
                            {
                                Console.WriteLine(qqq.FirstName + " " + qqq.LastName);
                            }
                        }
                    }
