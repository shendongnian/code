    var query = (from g in groupSet
                 join s in TotalServices on g.IDpack equals s.IDpack
                 group new { s, g } by g into grp
                 where !lstServices.CheckedItems.Cast<ListViewItem>().Select(x1 => x1.Tag).Except(grp.Select(x2 => x2.s.IDserv)).Any()
                 select grp.Key).ToList();
                  
