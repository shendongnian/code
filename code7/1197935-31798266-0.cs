            IndividualId = i.IndividualId,
            FirstName = i.FirstName,
            LastName = i.LastName,
            MiddleName = i.MiddleName,
            LicenseNumber = l.LicenseNumber
        };
    if (!string.IsNullOrEmpty(firstName))
    {
        query = query.Where(i => i.FirstName.StartsWith(firstName));
    }
    if (!string.IsNullOrEmpty(lastName))
    {
        query = query.Where(i => i.LastName.StartsWith(lastName));
    }
    if (!string.IsNullOrEmpty(middleName))
    {
        query = query.Where(i => i.MiddleName.StartsWith(middleName));
    }
    var result = query
        .OrderBy(i => i.FirstName)
        .ThenBy(i => i.LastName)
        .Take(50)
        .ToList();
