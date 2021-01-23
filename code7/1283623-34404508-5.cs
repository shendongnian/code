    public class CarsDto
    {
        public CarsDto()
        {
            Engines = new List<string>();
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Engines { get; set; }
    }
