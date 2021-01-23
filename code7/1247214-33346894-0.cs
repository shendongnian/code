    namespace MyProgram {
        internal class Program {
            private static void Main(string[] args) {
    
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                string dir = Path.GetDirectoryName(path);
                string pathToLoad = Path.Combine(dir, "MyCustomFolder");
                AdapterBase adapter = LoadAdapterFromPath(pathToLoad);
                adapter.PrintHello();
            }
    
            /// <summary>
            /// Loads the adapter from path. LoadFile will be used to find the correct type and then Assembly.Load will be used to actually load
            /// and instantiate the class.
            /// </summary>
            /// <param name="dir"></param>
            /// <returns></returns>
            public static AdapterBase LoadAdapterFromPath(string dir) {
                string assemblyName = FindAssembyNameForAdapterImplementation(dir);
                Assembly assembly = Assembly.Load(assemblyName);
                Type[] types = assembly.GetTypes();
                Type adapterType = null;
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(AdapterBase)))
                    {
                        adapterType = type;
                        break;
                    }
                }
                AdapterBase adapter;
                try {
                    adapter = (AdapterBase)Activator.CreateInstance(adapterType);
                } catch (Exception e) {
                    adapter = null;
                }
                return adapter;
            }
    
            public static string FindAssembyNameForAdapterImplementation(string dir) {
                string[] files = Directory.GetFiles(dir, "*.dll");
                foreach (var file in files)
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsSubclassOf(typeof(AdapterBase)))
                        {
                            return assembly.FullName;
                        }
                    }
                }
                return null;
            }
        }
    }
