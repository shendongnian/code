        private static IEnumerable<Assembly> GetModules()
        {
            if (_testContext)
            {
                return AppDomain.CurrentDomain.GetAssemblies();
            }
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (currentPath == null)
            {
                throw new NullReferenceException("Unable to build the container because currentPath variable is null.");
            }
            // XXXX = assign a wild card
            var libFolder = new DirectoryInfo(currentPath);
            var libFiles = libFolder.GetFiles("XXXX.*.dll", SearchOption.TopDirectoryOnly);
            return libFiles.Select(lib => Assembly.LoadFrom(lib.FullName)).ToList();
        }
