    var query =(from t in Context.Titles
                join td in Context.TitleDetails on t.id equals td.TitleId into tds
                from e in tds.DefaultIfEmpty()
                where e.OrderDate!=null
                group  e.OrderDate by new {t.Name, t.LimpIsbn, t.CasedIsbn} into groups
                from g in groups
                select new { Name = m.Key.Name,
                            LimpIsbn = g.Key.LimpIsbn,
                            CasedIsbn = g.Key.CasedIsbm,
                            LastOrder = g.Max(x => x)})
                .OrderBy(e=>e.LastOrder).Take(5);
            
            
