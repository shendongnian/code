    container.RegisterConditional<IUnitOfWork, EntityFrameworkUnitOfWork>(Lifestyle.Scoped,
        c => true);
    // NOTE: This registration must be made second
    container.RegisterConditional<IUnitOfWork, EmptyUnitOfWork>(Lifestyle.Singleton, 
        c => !c.Handled);
