        /// <summary>
        /// Gets the assemblies that belong to the application .exe subfolder.
        /// </summary>
        /// <returns>A list of assemblies.</returns>
        private static IEnumerable<Assembly> GetAssemblies()
        {
            string executableLocation = AppContext.BaseDirectory;
            string directoryToSearch = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");
            foreach (string file in Directory.EnumerateFiles(directoryToSearch, "*.dll"))
            {
                Assembly assembly = null;
                try
                {
                    //Load assembly using byte array
                    byte[] rawAssembly = File.ReadAllBytes(file);
                    assembly = Assembly.Load(rawAssembly);
                }
                catch (Exception)
                {
                }
                if (assembly != null)
                {
                    yield return assembly;
                }
            }
        }
