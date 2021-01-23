    public class Test
    {
        public int Id { get; set; }
        public string Testname { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
    public class Measurement
    {
        public int Id { get; set; }
        public int FullMeasurement { get; set; }
        public virtual Test Test { get; set; }
    }
