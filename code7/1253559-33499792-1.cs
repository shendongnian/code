    public class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return String.Format("Make: {0}, Year: {1}", Make, Year);
        }
    }
