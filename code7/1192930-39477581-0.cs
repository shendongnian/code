    public Debt FindAll()    
    {
       var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
       using (IDbConnection db = conn)
       {
          return db.Query<Debt>("Select * From Debt_Read");
       }
    }
