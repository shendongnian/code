    class Program
        {
            static void Main(string[] args)
            {
                var path =  @"Path\To\Your\Test\Dll";
                //load assembly:
                var assembly = Assembly.LoadFile(path);
                //get all public types:
                var types = assembly.GetExportedTypes();
                foreach (var t in types)
                {
                    Console.WriteLine(t.Name);
                    //check for [TestClass] attribute:
                    var attributes = t.GetCustomAttributes();
                    foreach (var attr in attributes)
                    {
                        var typeName = attr.TypeId.ToString();
                        Console.WriteLine(attr.TypeId);
                        if (typeName== "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute")
                        {
                            Console.WriteLine("It's MSTest");
                        }
                        else if (typeName == "Nunit.Tests.TestFixture") //not sure if that's the right type id :)
                        {
                            Console.WriteLine("It's NUnit");
                        }
                        else
                        {
                            Console.WriteLine("I Have no idea what it is");
                        }
                    }
                }
                Console.ReadLine();
    
            }
        }
