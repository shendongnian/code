    MappingConfiguration.Global.Define(
       new Map<Foo>()
          .TableName("foo")
          .KeyspaceName("ks1"),
       new Map<Bar>()
          .TableName("bar")
          .KeyspaceName("ks2"));
    
    ISession session = cluster.Connect();
    IMapper mapper = new Mapper(session);
