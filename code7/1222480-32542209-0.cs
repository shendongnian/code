        var allProviders = _db.CareProviders.AsQueryable();
        var resultItems = allProviders.Select(a => new
        {
            ProviderId = a.ProviderId, // fetch it as it is
            CareServiceType = a.CareServiceType,
            CareServiceName = a.CareServiceName,
            Email = a.Email
        })
        // download results from DB and execute
        // rest of the query on the application side
        .AsEnumerable()
        // now convert
        .Select(a => new
        {
            ProviderId = a.ProviderId.ToString(), //convert to string
            CareServiceType = a.CareServiceType,
            CareServiceName = a.CareServiceName,
            Email = a.Email
        });
