    public override bool Equals(object obj)
    {        
        MapLocation m = obj as MapLocation;
        return m == null ? false : m.x == x && m.y == y;
    }
    public override int GetHashCode()
    {
        return (x.ToString() + y.ToString()).GetHashCode();
    }
