    class Program
    {
        static void Main(string[] args)
        {
            var xdoc = XDocument.Load(@"C:\Xd.xml");
            Console.WriteLine("--------------------");
            Console.WriteLine("BEFORE");
            Console.WriteLine("--------------------");
            Console.WriteLine(xdoc.ToString());
            xdoc.Descendants().Where(d => d.Name.LocalName.Equals("descr") && d.Value.Equals("delete this")).Remove();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------");
            Console.WriteLine("AFTER");
            Console.WriteLine("--------------------");
            Console.WriteLine(xdoc.ToString());
            Console.ReadLine();
        }
    }
