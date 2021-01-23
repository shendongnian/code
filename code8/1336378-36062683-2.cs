    public class Weather
    {
        public double Degree { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
