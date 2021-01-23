    public static class PlanetSeedData
    {
        public static void Seed(Action<string> sql) 
        {
            sql("INSERT INTO dbo.Planets(Name) VALUES('Mercury')");
            sql("...");
        }
    }
