    class MyProxyFactoryFactory : DefaultProxyFactoryFactory, IProxyFactoryFactory
    {
        IProxyFactory IProxyFactoryFactory.BuildProxyFactory()
        {
            return new MyProxyFactory();
        }
    }
    class MyProxyFactory : AbstractProxyFactory, IProxyAssemblyBuilder
    {
        const string PathToSave = "D:/";
        private readonly ProxyFactory factory;
        public MyProxyFactory()
        {
            factory = new ProxyFactory(this);
        }
        public override INHibernateProxy GetProxy(object id, ISessionImplementor session)
        {
            try
            {
                var initializer = new DefaultLazyInitializer(EntityName, PersistentClass, id, GetIdentifierMethod, SetIdentifierMethod, ComponentIdType, session);
                object proxyInstance = IsClassProxy
                                        ? factory.CreateProxy(PersistentClass, initializer, Interfaces)
                                        : factory.CreateProxy(Interfaces[0], initializer, Interfaces);
                return (INHibernateProxy)proxyInstance;
            }
            catch (Exception ex)
            {
                throw new HibernateException("Creating a proxy instance failed", ex);
            }
        }
        public override object GetFieldInterceptionProxy(object instanceToWrap)
        {
            var interceptor = new DefaultDynamicLazyFieldInterceptor();
            return factory.CreateProxy(PersistentClass, interceptor, new[] { typeof(IFieldInterceptorAccessor) });
        }
        public AssemblyBuilder DefineDynamicAssembly(AppDomain appDomain, AssemblyName name)
        {
            return appDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave, PathToSave);
        }
        public ModuleBuilder DefineDynamicModule(AssemblyBuilder assemblyBuilder, string moduleName)
        {
            return assemblyBuilder.DefineDynamicModule(moduleName, moduleName + ".mod", true);
        }
        public void Save(AssemblyBuilder assemblyBuilder)
        {
            assemblyBuilder.Save("generatedAssembly.dll");
        }
    }
