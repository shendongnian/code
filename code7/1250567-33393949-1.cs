     var query = (from g in groupSet
                  join s in TotalServices on g.IDpack equals s.IDpack
                  group new {s, g} by g into grp
                  select new
                  {
                     Group = grp.Key,
                     Services = grp
                  }).Where(x => !lstServices.CheckedItems.Cast<ListViewItem>().Select(x1 => x1.Tag).Except(x.Services.Select(x2 => x2.Services.IDserv)).Any()).Select(a => a.Group).ToList();
