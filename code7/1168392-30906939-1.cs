    public AMap()
    {
        References(x => x.B);
    }
    public BMap()
    {
        References(x => x.C);
        HasMany(x => x.As);   // not needed
    }
    public CMap()
    {
        HasMany(x => x.Bs);   // not needed
        Map(x => x.ColumnY);
    }
