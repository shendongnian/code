    public List<Prueba> GetAllPruebas()
    {
        Database.SetInitializer(new DropCreateDatabaseAlways<OracleDbContext>());
        using (var ctx = new OracleDbContext())
        {
            return ctx.Pruebas.ToList();
        }
    }
