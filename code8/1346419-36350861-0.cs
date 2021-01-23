     public static class Extenstions
    {
        public static bool IsValid<T>(this string source) where T : struct
        {
            MethodInfo tryParse = (MethodInfo)typeof(T).GetMember("TryParse").FirstOrDefault();
            if (tryParse == null) return false;
            return (bool)tryParse.Invoke(null, new object[] { source, null });
        }
        public static Type GetParsableType(this string source)
        {
            return source.IsValid<int>()&&!source.Contains(".") ? typeof(int) : source.IsValid<double>() ? typeof(double) : typeof(string);
           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string x = Console.ReadLine();
                switch (x.GetParsableType().Name.ToLower())
                {
                    case "int32":
                    case "int":
                        int i = int.Parse(x);
                        i = i + 1;
                        Console.WriteLine(i); break;
                    case "double":
                        double d = double.Parse(x);
                        d = d + 1;
                        Console.WriteLine(d); break;
                    case "string":
                        string s = (x);
                        Console.WriteLine(s + "*"); break;
                    default: ; break;
                }
            }
        }
    }
