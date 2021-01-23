    // Assuming "var model" is coming in as a parameter
    var station = context.Viewers.First();
    station.Broadcasters = model.Broadcasters.Select(b => new User {
        Id = b.Id,
        SkypeId = b.SkypeId,
        Name = b.Name
    }).ToList();
    station.Viewers = model.Viewers.Select(v => new User {
        Id = v.Id,
        SkypeId = v.SkypeId,
        Name = v.Name
    });
