    [System.Web.Http.HttpGet]
    public async Task<A_Class> MyAPIMethodAsync(Guid b)
    {
      using (SqlConnection DB = new SqlConnection(this.dbConnString))
      {
        return await MyStaticHelper.AStaticMethodAsync(DB, b);
      }
    }
