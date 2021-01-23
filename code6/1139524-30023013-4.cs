    one.Concat(two).Select(g => g.Aggregate((p1,p2) => new One 
    {
        ID = p1.ID,
        Name = p1.PCName, 
        LastName = p1.LName,
        MainName = p2.mName
    }));
