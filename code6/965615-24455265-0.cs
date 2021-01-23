    var query = db.Customer.Select(c => new
    {
        c.ID,
        c.First_Name,
        c.Middle_Name,
        c.Last_Name,
    })
    .AsEnumerable()
    .Select(c => new
    {
        c.ID,
        FullNameLastFirstMiddle = 
            FormatName(c.First_Name, c.Middle_Name, c.Last_Name),
    });
