        enum Planet { Sun = 0, Moon = 1 }
        enum Abc { Abc5 = 0, Abc30 = 1 }
        private static void Main(string[] args)
        {
            var x = GetEnum<Planet>((long) 0);
            var y = GetEnum<Abc>((double)1);
            Console.WriteLine(x);
            Console.WriteLine(",  " + y);
        }
