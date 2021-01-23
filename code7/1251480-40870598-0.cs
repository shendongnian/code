    public YourDbContext()
              :base(name="YourDbContext")
    {
    this.Database.Connection.ConnectionString = "Data Source=****;Initial Catalog=****;User ID=****;Password=****";
    }
