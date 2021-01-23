    var query = (from r in context.TableA
            join c in context.TableB
            on r.Id equals c.FK
            join m in context.TableC
            on r.Id equals m.FK
            
            group m by new { r, c } into grouping
            select new MyViewModel
            {
                 A = grouping.Key.r,
                 B = grouping.Key.c,
                 C = grouping.ToList()
             }).ToList();
