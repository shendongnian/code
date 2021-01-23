        private void AddBindings()
        {
            ninjectKernel.Bind<IFlightRepoFactory>().ToFactory();
            ninjectKernel.Bind<IAirportRepoFactory>().ToFactory();
            ninjectKernel.Bind<IPaxRepoFactory>().ToFactory();
            ninjectKernel.Bind<IRepoFactory>().ToFactory();
            ninjectKernel.Bind<IRepoCollectionFactory>().ToFactory();
            ninjectKernel.Bind<IRepositories>().To<EFRepositories>();
            ninjectKernel.Bind<IRepositoryCollection>().To<EFRepositoryCollection>();
            ninjectKernel.Bind<IFlightRepository>().To<EFFlightRepository>();
            ninjectKernel.Bind<IPaxRepository>().To<EFPaxRepository>();
            ninjectKernel.Bind<IAirportRepository>().To<EFAirportRepository>();
        }
