    class DependencyWalker
    {
        Dictionary<string, DependencyTree> _alreadyProcessed = new Dictionary<string, DependencyTree>();
        public DependencyTree GetDependencyTree(Assembly assembly)
        {
            // Avoid procesing twice same assembly.
            if (_alreadyProcessed.ContainsKey(assembly.FullName)) 
                return _alreadyProcessed[assembly.FullName]; 
            var item = new DependencyTree();
            item.AssemblyName = assembly.FullName;
            item.ReferencedAssemblies = new Dictionary<string, DependencyTree>();
            _alreadyProcessed.Add(item.AssemblyName, item);
            foreach (AssemblyName assemblyName in assembly.GetReferencedAssemblies())
            {
                item.ReferencedAssemblies.Add(assemblyName.FullName, GetDependencyTree(Assembly.Load(assemblyName)));
            }
            return item;
        }
        // To print the tree to the console:
        public void PrintTree(DependencyTree tree)
        {
            PrintTree(tree, 0, new Dictionary<string, bool>()); // Using Dictionary because HashSet is not available on .NET 2.0
        }
        private void PrintTree(DependencyTree tree, int indentationLevel, IDictionary<string,bool> alreadyPrinted)
        {
            Console.WriteLine(new string(' ', indentationLevel) + tree.AssemblyName);
            if (alreadyPrinted.ContainsKey(tree.AssemblyName))
                return;
            alreadyPrinted[tree.AssemblyName] = true;
            foreach (DependencyTree a in tree.ReferencedAssemblies.Values)
                PrintTree(a, indentationLevel + 3, alreadyPrinted);
        }
    }
