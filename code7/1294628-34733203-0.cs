    var result =
        context
        .Organisations
        .Select(org =>
            new
            {
                Name = org.Name, //Assuming that you have a `Name` property on Organisation
                UpcommingEvent = 
                    org.Events
                    .Where(e => e.PremiereDateTime >= DateTime.UtcNow)
                    .OrderBy(e => e.PremiereDateTime)
                    .FirstOrDefault()
            })
        .ToList();
