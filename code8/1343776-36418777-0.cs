    /// <summary>
    /// Export attribute to allow registering components using autofac. 
    /// This attribute must be used for all pluggable components that require to be discovered dynamically.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute:Attribute
    {
        private Type type;
        public ExportAttribute(Type type)
        {
            this.type = type;
        }
        /// <summary>
        /// Provides the type (any interface) of Export
        /// </summary>
        public Type Type { get { return this.type; } }
    }
	
	    /// <summary>
        /// Registers components based on Export attribute containing their type information
        /// </summary>
        private void BuildContainer()
        {
           var allAssemblies = AssemblyInitializer.GetLoadedPlugins();
           allAssemblies.ForEach(assembly =>
            {
                var allTypes = assembly.GetTypes().Where(a => a.GetCustomAttribute(typeof(ExportAttribute)) != null).ToList<Type>();             
                allTypes.ForEach(y =>
                {
                    var classType = ((ExportAttribute)(y.GetCustomAttribute(typeof(ExportAttribute)))).Type;
                    if (!classType.IsInterface || !classType.IsAbstract || !classType.IsPublic) return;
                    if (classType.Equals(typeof(IRepository<>)))
                    {
                        builder.RegisterGeneric(y.GetTypeInfo()).Named(y.GetTypeInfo().Name, typeof(IRepository<>));
                    }
                    // Handle code for any other specific Interfaces                           
                });
            });
            this.Container = builder.Build();
        } 
