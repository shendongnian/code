    IQueryable<ReservationsView> queryRes;
    queryRes = (from p in ctx.Reservations
                               join a in ctx.Employees on p.Id_employee equals a.Id
                               join c in ctx.Clients on p.Id_client equals c.Id
                               orderby p.Id
                               select new ReservationsView
                               {
                                   p.Date,
                                   p.Hour,
                                   c.Name,
                                   c.Surname,
                                   p.Email,
                                   p.Phone,
                                   p.Service,
                                   name1=a.Nume,
                                   surname1=a.Prenume
                               });
