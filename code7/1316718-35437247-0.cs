    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            Console.WriteLine("=====Working with URI...=====");
            WorkWithUri();
            Console.WriteLine("=====Working with XML...=====");
            WorkWithXml();
        }
        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine(args.LoadedAssembly.FullName + " has been loaded.");
        }
        private static void WorkWithUri()
        {
            var uri = new Uri("c:\\");
        }
        private static void WorkWithXml()
        {
            XDocument xml = new XDocument();
        }
    }
