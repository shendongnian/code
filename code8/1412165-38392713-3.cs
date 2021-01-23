      class Program
        {
            static void Main(string[] args)
            {
                var assembly = Assembly.LoadFile(Path.GetFullPath("PrivateLib.dll"));
                var myClass = assembly.GetType("PrivateLib.MyClass");
                //var instance = myClass.GetConstructor(new Type[]{}).Invoke(new object[] { });
                var method = myClass.GetMethod("Foo", BindingFlags.NonPublic | BindingFlags.Static);
                var result = method.Invoke(new object(), new object[]{});
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
