    class Program
    {
        static void Main(string[] args)
        {
            //var configValue = XDocument.Parse("<config><hardware>type1</hardware></config>").Document.Descendants("hardware").First().Value;
            var configValue = XDocument.Load("MyXmlConfig.xml").Document.Descendants("hardware").First().Value;
            if (configValue == "type1")
            {
                System.Reflection.Assembly.LoadFile(@"C:\TEMP\MyAssembly_Type1.dll");
            }
            else if (configValue == "type2")
            {
                System.Reflection.Assembly.LoadFile(@"C:\TEMP\MyAssembly_Type2.dll");
            }
            MyRepositoryClass.Initialize();
        }
    }
    static class MyRepositoryClass
    {
        public static void Initialize()
        {
            var variable1 = MyAssembly.MyRepository.Variable1;
            var variable2 = MyAssembly.MyRepository.Variable2;
            var variable3 = MyAssembly.MyRepository.Variable3;
        }
    }
