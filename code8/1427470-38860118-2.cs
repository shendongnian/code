    var factory = new Configuration().Configure().SetProperty(
        "connection.connection_string",
        connectionStrings["db1"].ConnectionString)
        .BuildSessionFactory();
    var session1Producer = Lifestyle.Scoped.CreateProducer<ISession>(
        factory.OpenSession, container);
    container.RegisterSingleton<IDb1SessionProvider>(
        new FuncDb1SessionProvider(session1Producer.GetInstance));
