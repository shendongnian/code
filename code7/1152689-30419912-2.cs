        /// <summary>
        /// This class contains methods to construct a concrete object from an interface.
        /// </summary>
        public static class ServiceFactory
        {
    
    
            /// <summary>
            /// Builds a concrete instance of an interface
            /// </summary>
            /// <typeparam name="T">The interface of the object</typeparam>
            /// <returns>If found, a concrete object is returned that implements the interface</returns>
            public static T Build<T>() where T : class
            {
                string applicationPath = AppDomain.CurrentDomain.BaseDirectory;
    
                string[] files = Directory.GetFiles(applicationPath, "*.dll");
    
                foreach (string file in files)
                {
                    // Dynamically load the selected assembly.
                    Assembly theAssembly = Assembly.LoadFrom(file);
    
                    // See if the type implements T.
                    foreach (Type type in theAssembly.GetTypes())
                    {
                        if (ImplementsInterface(type, typeof(T)))
                        {
                            // Use late binding to create the type.
                            return (T) theAssembly.CreateInstance(type.FullName);
                        }
                    }
                }
                return null;
            }
    
            public static bool ImplementsInterface(this Type type, Type ifaceType)
            {
                return type.GetInterfaces().Any(x => x == ifaceType);
            }
    
    }
