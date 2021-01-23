    public static bool EqualsAny(this Thing thing, params object[] compare)
    {
        foreach (object obj in compare)
        {  
            if (obj == thing) return true;
        }
        return false;
    }
    bool result = BigObjectThing.Uncle.PreferredInputStream.NthRelative(5).EqualsAny(x, y, z);
