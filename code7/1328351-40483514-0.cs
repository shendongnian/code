        public static IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }
                var builder = new ContainerBuilder();
                foreach (var lib in GetModules())
                {
                    builder.RegisterAssemblyModules(lib);
                }
                _container = builder.Build();
                return _container;
            }
        }
