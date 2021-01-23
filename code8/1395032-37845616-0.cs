            using (var db = new Db(ConnectionString))
            {
                IQueryable<dbase> query = cmax.dbases.Where(w => w != null);
                var results = new List<dbase>();
               
                        if (portfolioSelected != null)
                            query = query.Where(w => portfolioSelected.Any(a => a == w.portfolio));
                        if (statusSelected != null)
                            query = query.Where(w => statusSelected.Any(a => a == w.statusname));
                        if (deskSelected != null)
                            query = query.Where(w => deskSelected.Any(a => a == w.assignedto)); break;
     
                results = await query.ToListAsync();
            }
