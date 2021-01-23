    <add name="dbConnectionString" connectionString="metadata=res://*/Models.YourEntityModel.csdl|res://*/Models.YourEntityModel.ssdl|res://*/Models.YourEntityModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=yourdatasource;initial catalog=yourdb;persist security info=True;user id=username;password=password;multipleactiveresultsets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    [TestMethod]
    public void MyTestMethod()
    {
        //Arrange
        //Then you can specify your connection string with its name:
        EntityConnection connection =
        Effort.EntityConnectionFactory.CreateTransient("name=dbConnectionString");
        //Act
        var usersCount;
        using (MyDbContext ctx= new MyDbContext(connection))
        {
            usersCount = ctx.Users.Count();
        }
        //Assert
        //Put your assert logic here:
        Assert.IsTrue(usersCount == 100);
    }
