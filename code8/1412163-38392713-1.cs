    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFile(Path.GetFullPath("PrivateLib.dll"));
            var myClass = assembly.GetType("PrivateLib.MyClass");
            var instance = myClass.GetConstructor(new Type[]{}).Invoke(new object[] { });
            var method = myClass.GetMethod("Foo", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = method.Invoke(instance, new object[]{});
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
