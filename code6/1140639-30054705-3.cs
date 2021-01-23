        static void Main(string[] args)
        {
            var k = new kid { age = 23, name = "Paolo", toys = new List<string>() };
            k.toys.Add("Pippo");
            k.toys.Add("Pluto");
            Console.WriteLine(k.ApiCustomView);
            Console.ReadLine();
        }
