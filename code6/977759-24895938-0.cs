    <add name="dbConnectionString" connectionString="metadata=res://*/Models.YourEntityModel.csdl|res://*/Models.YourEntityModel.ssdl|res://*/Models.YourEntityModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=yourdatasource;initial catalog=yourdb;persist security info=True;user id=username;password=password;multipleactiveresultsets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    [TestMethod]
    public void TestMethod1()
    {
        //Then you can specify your connection string with its name:
        IDataLoader loader = new EntityDataLoader("name=dbConnectionString");
        using (var ctx = new UsersDbContext(Effort.DbConnectionFactory.CreatePersistent("cool", loader)))
        {
            var usersCount = ctx.Users.Count();
        }
    }
