    static void Main(string[] args)
        {
            MyModel mm = new MyModel();
            mm.Id = 1;
            mm.Name = "user3728304";
            mm.Points = 1;
            mm.Features = new List<Feature>{Feature.one,
                             Feature.two,
                             Feature.three};
            Console.Read();
        }
