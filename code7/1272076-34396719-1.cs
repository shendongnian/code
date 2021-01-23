    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            MyRepositoryClass.Initialize();
        }
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("MyAssembly")) //Put in the name of your assembly
            {
                //var configValue = XDocument.Parse("<config><hardware>type1</hardware></config>").Document.Descendants("hardware").First().Value;
                var configValue = XDocument.Load("MyXmlConfig.xml").Document.Descendants("hardware").First().Value;
                if (configValue == "type1")
                {
                    return System.Reflection.Assembly.LoadFile(@"C:\TEMP\MyAssembly_Type1.dll");
                }
                else if (configValue == "type2")
                {
                    return System.Reflection.Assembly.LoadFile(@"C:\TEMP\MyAssembly_Type2.dll");
                }
            }
            return null;
        }
    }
