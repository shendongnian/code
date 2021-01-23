    public class DummyModule
    {
        public List<string> getDependencies()
        {
            List<string> lDependencies = new List<string>();
            
            var assembly = Assembly.ReflectionOnlyLoadFrom(Assembly.GetExecutingAssembly().Location);
            var referencedAssemblies = assembly.GetReferencedAssemblies();
            foreach (var assemblyName in referencedAssemblies)
            {
                lDependencies.Add(assemblyName.Name);
            }
            if (lDependencies.Contains("mscorlib"))
                lDependencies.Remove("mscorlib");
            return lDependencies;
        }
        public void A()
        {
            Cryptography c = new Cryptography();
        }
     }
