    container.Register(typeof(IMapper<,>), typeof(Mapper<,>), Reuse.Singleton,
        // will select second constructor with Func parameter
        made: FactoryMethod.ConstructorWithResolvableArguments);
    // normal model registrations, no need to use Made.Of
    // if implementations have single constructor,
    // othetwise try use the same made as for Mapper.
    container.Register<IActivitiesModel, ActivitiesModel>();
    // ... the same way register repository, vm, etc. 
