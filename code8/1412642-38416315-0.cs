    public override object GetValue(int ordinal)
    {
        object value = Accessors[ordinal](Enumerator.Current);
    
        var dbgeo = value as DbGeography;
        if (dbgeo != null)
        {
            var chars = new SqlChars(dbgeo.WellKnownValue.WellKnownText);
            return SqlGeography.STGeomFromText(chars, dbgeo.CoordinateSystemId);
        }
    
        var dbgeom = value as DbGeometry;
        if (dbgeom != null)
        {
            var chars = new SqlChars(dbgeom.WellKnownValue.WellKnownText);
            return SqlGeometry.STGeomFromText(chars, dbgeom.CoordinateSystemId);
        }
    
        return value;
    }
