    public CompanyMap()
    {
        Id(x => x.Id).Column("CompanyId");
    
    
        HasOne(x => x.HeadQuarter)
                .PropertyRef(x => x.Company);
    }
    
    public HeadQuarterMap()
    {
        Id(x => x.Id)
            .Column("HeadQuarterId");
        References( x => x.Company, "CompanyId" ).Unique();
    }
