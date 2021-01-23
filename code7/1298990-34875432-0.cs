    public class Person
    {
        public string Name { get; set; }
        public string[] Cars { get; set; }
        public int NoOfCars { get { return Cars == null ? 0 : Cars.Length; } }
    }
