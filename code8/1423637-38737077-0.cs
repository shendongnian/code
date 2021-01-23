    class DependencyTree
    {
        public string AssemblyName;
        public IDictionary<string,DependencyTree> ReferencedAssemblies;
    }
