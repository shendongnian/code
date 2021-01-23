    public static class RikropCoreDataUnityExtensions
    {
        #region Const
        private readonly static Type _repositoryInterfaceType = typeof(IRepository<,>);
        private readonly static Type _deactivatableRepositoryInterfaceType = typeof(IDeactivatableRepository<,>);
        private readonly static Type _deactivatableEntityType = typeof(DeactivatableEntity<>);
        private readonly static Type _retrievableEntityType = typeof(IRetrievableEntity<,>);
        #endregion Const
        #region public methods
        /// <summary>
        /// Register wrapper class.
        /// </summary>
        /// <typeparam name="TContext">DbContext type.</typeparam>
        /// <param name="container">Unity-container.</param>
        public static void RegisterRepositoryContext<TContext>(this IUnityContainer container)
            where TContext : DbContext, new()
        {
            container.RegisterType<IRepositoryContext, RepositoryContext>(new InjectionFactory(c => new RepositoryContext(new TContext())));
        }
        /// <summary>
        /// Register wrapper class.
        /// </summary>
        /// <typeparam name="TContext">DbContext type.</typeparam>
        /// <param name="container">Unity-container.</param>
        /// <param name="contextConstructor">DbContext constructor.</param>
        /// <param name="connectionString">Connection string name.</param>
        public static void RegisterRepositoryContext<TContext>(this IUnityContainer container,
            Func<string, TContext> contextConstructor, string connectionString)
            where TContext : DbContext
        {
            container.RegisterType<IRepositoryContext, RepositoryContext>(
                new InjectionFactory(c => new RepositoryContext(contextConstructor(connectionString))));
        }
        /// <summary>
        /// Automatically generation and registration for generic repository marked by attribute.
        /// </summary>
        /// <param name="container">Unity-container.</param>
        /// <param name="assembly">Assembly with repositories marked with RepositoryAttribute.</param>
        public static void RegisterCustomRepositories(this IUnityContainer container, Assembly assembly)
        {
            foreach (var repositoryType in assembly.GetTypes().Where(type => type.IsClass))
            {
                var repositoryAttribute = repositoryType.GetCustomAttribute<RepositoryAttribute>();
                if (repositoryAttribute != null)
                {
                    container.RegisterType(
                        repositoryAttribute.RepositoryInterfaceType, 
                        repositoryType,
                        new TransientLifetimeManager());
                }
            }
        }
        /// <summary>
        /// Automatically generation and registration for generic repository for all entities.
        /// </summary>
        /// <param name="container">Unity-container.</param>
        /// <param name="assembly">Assembly with Entities which implements IRetrievableEntity.</param>
        public static void RegisterRepositories(this IUnityContainer container, Assembly assembly)
        {
            foreach (var entityType in assembly.GetTypes().Where(type => type.IsClass))
            {
                if (!entityType.InheritsFromGeneric(_retrievableEntityType))
                    continue;
                Type[] typeArgs = entityType.GetGenericTypeArguments(_retrievableEntityType);
                Type constructedRepositoryInterfaceType = _repositoryInterfaceType.MakeGenericType(typeArgs);
                container.RegisterRepository(constructedRepositoryInterfaceType);
                if (entityType.InheritsFrom(_deactivatableEntityType.MakeGenericType(new[] { typeArgs[1] })))
                {
                    var constructedDeactivatableRepositoryInterfaceType =
                        _deactivatableRepositoryInterfaceType.MakeGenericType(typeArgs);
                    container.RegisterRepository(constructedDeactivatableRepositoryInterfaceType);
                }
            }
        }
        #endregion public methods
        #region private methods
        /// <summary>
        /// Generate and register repository.
        /// </summary>
        /// <param name="container">Unity-container.</param>
        /// <param name="repositoryInterfaceType">Repository interface type.</param>
        private static void RegisterRepository(this IUnityContainer container, Type repositoryInterfaceType)
        {
            var factoryGenerator = new RepositoryGenerator();
            var concreteFactoryType = factoryGenerator.Generate(repositoryInterfaceType);
            container.RegisterType(
                repositoryInterfaceType,
                new TransientLifetimeManager(),
                new InjectionFactory(
                    c =>
                    {
                        var activator = new RepositoryActivator();
                        return activator.CreateInstance(c, concreteFactoryType);
                    }));
        }
        #endregion private methods
    }
