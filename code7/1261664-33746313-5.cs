        public class Configuration
        {
            public Tuple<int, int, int>[] MyThreeTuple { get; set; }
            public Configuration()
            {
                MyThreeTuple = new[]
                {
                    new Tuple<int, int, int>(-100, 20, 501),
                    new Tuple<int, int, int>(100, 20, 864),
                    new Tuple<int, int, int>(500, 20, 1286),
                };
            }
        }
