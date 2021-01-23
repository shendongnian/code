	void RegisterDocumentDbRepository<TRepository, TCollection>(ContainerType container)
	{
		container.RegisterType<IDocumentCollectionName, TCollection>(typeof(TRepository).Name);
		var constructor = new InjectionConstructor(new ResolvedParameter<IDocumentCollectionName>(typeof(TRepository).Name));
		container.RegisterType<IDocumentDbRepository<TRepository>, DocumentDbRepository<TRepository>>(constructor);
	}
