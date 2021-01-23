    class Program
    {
        static void Main(string[] args)
        {
            var domain = AppDomain.CreateDomain("type-provider-appdomain");
            var typeProviderInstance = domain.CreateInstanceAndUnwrap(typeof(TypesProvider).Assembly.FullName, typeof(TypesProvider).FullName) as TypesProvider;
            if (typeProviderInstance != null)
            {
                Console.WriteLine("Types for the executing assembly");
                var types = typeProviderInstance.RetrieveTypes();
                foreach (var type in types)
                {
                    Console.WriteLine(type);
                }
                var assemblyFile = new FileInfo("EntityFramework.dll").FullName;
                Console.WriteLine("Types for assembly " + assemblyFile);
                types = typeProviderInstance.RetrieveTypesForAnotherAssembly(assemblyFile);
                foreach (var type in types)
                {
                    Console.WriteLine(type);
                }
            }
            Console.ReadLine();
        }
    }
