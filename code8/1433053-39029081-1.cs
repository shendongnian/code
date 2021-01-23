    public bool ContainsOnly(X value, X flags) 
    {
         return value == flags;
    }
    public bool ContainsOnlyCandD(X value) 
    {
         return value == (X.c | X.d);
    }
    public bool ContainsBothCandDButCouldContainOtherStuffAsWell(X value) 
    {
         return (value & (X.c | X.d)) == (X.c | X.d);
    }
