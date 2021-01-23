            IQueryable<Reservations> queryRes;
            queryRes = (from p in ctx.Reservations
                        join a in ctx.Employees on p.Id_employee equals a.Id
                        join c in ctx.Clients on p.Id_client equals c.Id
                        orderby p.Id
                        select p);
            reservationsView.Source = queryRes.ToList();
