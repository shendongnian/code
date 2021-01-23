    class Program
    {
        static void Main(string[] args)
        {            
            var asy = Assembly.LoadFrom(@"<path>\A.dll");
            var pw = asy.GetTypes()[0];
            var method = pw.GetMethod("G", BindingFlags.NonPublic|BindingFlags.Static);
        }
    }
