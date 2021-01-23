    container.Register(
        Component.For<DataConnection>().UsingFactoryMethod(x => 
            CreateDataConnection()).LifestyleScoped(),
        Component.For<IData<Vehicle>>()
            .ImplementedBy<VehicleData>().LifestyleScoped()
    );
    private static DataConnection CreateDataConnection()
    {
        return new DataConnection(new SqlServerDataProvider("", SqlServerVersion.v2008), 
            @"Data Source=(local);Initial Catalog=DB1;Persist Security Info=True;User ID=user;Password=pwd");
    }
