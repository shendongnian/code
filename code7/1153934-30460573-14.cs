    var activeItems = (from o in db.SomeTables
                       where o.IsActive
                       group o by o.Name into gr
                       select new { gr.Key, cc = gr.Select(c => c.Foo).Distinct().Count(c => c != null) + 
                                                 gr.Select(c => c.Bar).Distinct().Count(c => c != null) }).ToDictionary(c => c.Key);
