     public ICollection<Assembly> GetAssemblies(string pathOfDLL)
        {
            List<Assembly> baseAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var controllersAssembly = Assembly.LoadFrom(pathOfDLL);
            baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;
        }
