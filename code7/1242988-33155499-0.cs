    KerlServices
        .AsNoTracking()
        .Select(ks => new {
            ks.KerlCode,
            ks.Service.SAPProductNumber,
            ks.Service.Type })
        .Where(ks => Articles.Any(a => a.Active == "J" && a.SAPProductNumber == ks.SAPProductNumber)
        .ToList()
