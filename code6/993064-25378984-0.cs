    sqlg = SqlGeography.STMPolyFromText(
    new SqlChars(town.TownBoundary.WellKnownValue.WellKnownText),
    town.TownBoundary.CoordinateSystemId);
    for (int i = 1; i <= sqlg.STNumGeometries(); i++)
    {
     SqlGeography poly = sqlg.STGeometryN(i);
     //foreach poly
    } 
