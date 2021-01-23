        internal class Program
        {
            private static void Main(string[] args)
            {
                var type = typeof(Interface1);
                Assembly loadedAssembly = type.Assembly;
                var types = loadedAssembly.GetTypes().Where(c => type.IsAssignableFrom(c));
    
                foreach (var typeFound in types)
                {
                    Console.WriteLine(typeFound.Name);
                }
    
                Console.ReadKey();
            }
        }
