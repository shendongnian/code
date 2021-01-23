    public override void Up()
    {
        // CreateTable(...)
        PlanetSeedData(x => Sql(x));
    }
