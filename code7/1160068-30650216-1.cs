    public static bool EqualsAny(this Thing thing, params object[] compare)
    {
        return compare.Contains(thing);
    }
    bool result = BigObjectThing.Uncle.PreferredInputStream.NthRelative(5).EqualsAny(x, y, z);
