    DbContext dbcontext;
    public HomeController()
    {
        this.dbcontext = new DbContext(Connections.connection);
    }
    var laptops = dbcontext.Database.SqlQuery<Laptop>(@"exec [dbo].[sp_Select_Laptop]");
