                container.RegisterType(Of IDataContextAsync, dbEntities)("db", New InjectionConstructor())
                container.RegisterType(Of IUnitOfWorkAsync, UnitOfWork)("UnitOfWork", New InjectionConstructor(New ResolvedParameter(Of IDataContextAsync)("db")))
        
                'Exceptions example
                container.RegisterType(Of IRepositoryAsync(Of Exception), Repository(Of Exception))("iExceptionRepository",
                                                                                                             New InjectionConstructor(New ResolvedParameter(Of IDataContextAsync)("db"),
                                                                                                                                      New ResolvedParameter(Of IUnitOfWorkAsync)("UnitOfWork")))
    
    
