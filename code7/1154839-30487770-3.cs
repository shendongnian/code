    public List<Prueba> GetAllPruebas()
    {
       using (var ctx = new OracleDbContext())
        {
            return ctx.Pruebas.ToList();
        }
    }
