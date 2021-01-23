    class Program
    {
        static void Main(string[] args)
        {
            new System.Xml.XmlDocument().LoadXml("<xml/>"); // Do whatever to ensure System.Xml assembly is referenced.
            var startingAssembly = typeof(Program).Assembly;
            var walker = new DependencyWalker();
            var tree = walker.GetDependencyTree(startingAssembly);
            walker.PrintTree(tree);
        }
    }
