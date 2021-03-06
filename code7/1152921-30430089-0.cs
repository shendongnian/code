    from b in db.Bases
    select new BaseDTO
    {
        BaseName = b.BaseName,
        BaseStart = b.BaseStart,
        BaseEnd = b.BaseEnd,
        Clients =
            from ba in b.BaseAssignments 
            join c in db.Clients on ba.ClientId equals c.ClientId
            select new ClientDTO
            {
                ClientId = c.ClientId,
                CompanyName = c.CompanyName,
                Owner = c.Owner
            }
     };
