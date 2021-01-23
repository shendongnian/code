    // firstly 
    // the original part from the question above
    baseQuery.SelectList(list => list
        ...
        .Select(() => joinedBriefBestemmeling.BinnenLand)
           .WithAlias(() => nieuwePrintopdrachtInfo.BestemmelingBinnenLand)
        .Select(() => joinedVerbruiksAdres.Land)
           .WithAlias(() => nieuwePrintopdrachtInfo.LandVerbuiksadres)
        .Select(Projections.Property(() => joinedContactpersoon.ContactpersoonId)
           .As("BestemmelingContactPersoon.ContactPersoonId"))
        .Select(Projections.Property(() => joinedContactpersoonType.Omschrijving)
           .As("BestemmelingContactPersoon.TypeContactPersoon"))
        ...
    
    
    
    // changed, to use GROUP BY
    baseQuery.SelectList(list => list
        ...
        .SelectGroup(() => joinedBriefBestemmeling.BinnenLand)
           .WithAlias(() => nieuwePrintopdrachtInfo.BestemmelingBinnenLand)
        .SelectGroup(() => joinedVerbruiksAdres.Land)
           .WithAlias(() => nieuwePrintopdrachtInfo.LandVerbuiksadres)
        .Select
           (Projections.Alias
             (Projections.GroupProperty
               (Projections.Property(() => joinedContactpersoon.ContactpersoonId))
             , "BestemmelingContactPersoon.ContactPersoonId"))
        .Select
           (Projections.Alias
             (Projections.GroupProperty
               (Projections.Property(() => joinedContactpersoonType.Omschrijving))
             , "BestemmelingContactPersoon.TypeContactPersoon"))
         ...
