        static void Main(string[] args)
        {
            IEnumerable<string> output;
            var countries = new[]
            {
                new { Name = "Frankrijk", Oppervlake = 643274 },
                new { Name = "Nederland", Oppervlake = 41528},
                new { Name = "Belgium", Oppervlake = 25812}
            };
            Console.WriteLine("selected name");
            output = countries.Where(x => x.Oppervlake > 100).Select(x => x.Name);
            foreach (var v in output)
                Console.WriteLine(v);
            Console.ReadLine();
        }
