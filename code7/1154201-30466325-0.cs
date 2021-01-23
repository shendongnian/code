    var query = from sb in db.Surfboards
                        join csb in db.CustomerSurfBoards on sb.SurfBoardID equals csb.SurfBoardID
                        join c in db.Customers on csb.CustomerID equals c.CustomerID
                        where c.IsActive
                        select new {sb.id, c.number, cbs.componentid} into tmp
                        from t in tmp
                        group t by new {t.ID, t.ComponentId} into g
                        select new
                        {
                            g.Key.id, g.Key.componentid, number = g.Select(n=>n.number).OrderByDescending().FirstOrDefault()
                        }
