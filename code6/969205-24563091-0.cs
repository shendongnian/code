    public class PluginMgr<T> where T : class
    {
        public PluginMgr()
        {
            this.Plugins = new List<T>();
        }
        /// <summary>
        /// The list of plugin instances that were found and created.
        /// </summary>
        public List<T> Plugins { get; private set; }
        /// <summary>
        /// Scans loaded assemblies for classes that implement the interface specified by the type 
        /// parameter, then instantiates and stores any classes that are found.
        /// </summary>
        public void Initialize()
        {
            ForceLoadAssemblies();
            FindPlugins();
        }
        /// <summary>
        /// Attempts to force the VM to load all assemblies that are referenced by any assembly 
        /// implicated in the call stack. Referenced assemblies are not loaded until reference 
        /// resolution happens that depends on that assembly; if an assembly X has a reference to
        /// another assembly Y, but X never uses anything from Y, then Y is never loaded; that is to 
        /// say, the .Net assembly loader uses 'lazy loading'.
        /// 
        /// This is necessary because our plugin sniffing logic won't find the plugins that don't
        /// have their defining assembly loaded. If we forcibly load the assembly, then we'll guarentee
        /// that we find the assembly.
        /// </summary>
        private void ForceLoadAssemblies()
        {
            StackFrame[] frames;
            AssemblyName[] refedAssemblies;
            Assembly assembly;
            frames = new StackTrace().GetFrames();
            foreach (StackFrame frame in frames)
            {
                assembly = frame.GetMethod().DeclaringType.Assembly;
                refedAssemblies = assembly.GetReferencedAssemblies();
                foreach (AssemblyName refedAssembly in refedAssemblies)
                {
                    Assembly.Load(refedAssembly);
                }
            }
        }
      
        /// <summary>
        /// Scan through every loaded assembly to find types that are implementors of our
        /// given interface.
        /// </summary>
        private void FindPlugins()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type interfaceType = typeof(T);
            foreach( Assembly assembly in assemblies )
            {
                Type[] types = assembly.GetExportedTypes();
                foreach( Type type in types )
                {
                    if( type.GetInterfaces().Contains( interfaceType ) )
                    {
                        T plugin = Activator.CreateInstance( type ) as T;
                        this.Plugins.Add( plugin );
                    }
                }
            }
        }
