    ISession session1 = cluster.Connect("ks1");
    ISession session2 = cluster.Connect("ks2");
    
    IMapper mapper1 = new Mapper(session1, new MappingConfiguration());
    IMapper mapper2 = new Mapper(session2, new MappingConfiguration());
