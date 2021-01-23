        public class Tyre
        {
            public int Id { get; set; }
        }
        public class Vehicle
        {
            public string Id { get; set; }
            public IList<Tyre> Tyres { get; set; } = new List<Tyre>();
        }
