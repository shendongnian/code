        private ResourceManager GetResourceManager(Assembly assembly)
        {
            // Guess namespace name 
            var namespaceName = Path.GetFileNameWithoutExtension(assembly.CodeBase);
            namespaceName = namespaceName + ".Properties.Resources";
            return new ResourceManager(namespaceName, assembly);
        }
