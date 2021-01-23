    public IEnumerable<Assembly> GetAssemblyDependencies(Assembly assembly)
    {
        HashSet<string> hash = new HashSet<string>();
    
        Func<AssemblyName, Assembly> loader = (name) =>
        {
            try
            {
                return Assembly.Load(name.FullName);
            }
            catch
            {
                return null;
            }
        };
    
        List<Assembly> queue = new List<Assembly>() { assembly };
        List<Assembly> newQueue = new List<Assembly>();
        while (queue.Count != 0)
        {
            foreach (var asm in queue.SelectMany(e => from x in e.GetReferencedAssemblies()
                                                      let loadedAssembly = loader(x)
                                                      where loadedAssembly != null
                                                      select loadedAssembly))
            {
                string fullName = asm.FullName;
                if (!hash.Contains(fullName))
                {
                    // new assembly
                    hash.Add(fullName);
                    yield return asm;
                    newQueue.Add(asm);
                }
            }
    
            var temp = queue;
            queue = newQueue;
            newQueue = temp;
            newQueue.Clear();
        }
    }
