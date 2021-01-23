    class Program
    {
        private static void Main(string[] args)
        {
            var methods = new Dictionary<string, Action>();
            //choose your poison:
            methods["M1"] = MethodOne; //method reference
            methods["M2"] = () => Console.WriteLine("Two"); //lambda expression
            methods["M3"] = delegate { Console.WriteLine("Three"); }; //anonymous method
            //call `em
            foreach (var method in methods)
            {
                method.Value();
            }
            //or like tis
            methods["M1"]();
        }
        static void MethodOne()
        {
            Console.WriteLine("One");
        }
    }
