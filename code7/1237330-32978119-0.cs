    class MyConfig
    {
        public Vehicle Vehicle { get; set; }
    }
    class Vehicle
    {
        public string Description { get; set; }
        public int Mpg { get; set; }
        public Paint Paint { get; set; }
    }
    class Paint
    {
        public string MajorColor { get; set; }
        public string MinorColor { get; set; }
    }
    public class Program
    {
        public void Main(string[] args)
        {
            var config = new ConfigurationBuilder();
            config.AddXmlFile(@"x.xml");
            var configuration = config.Build();
            //Approach 1 (top level object)
            var topConfig = new MyConfig();
            configuration.Bind(topConfig);
            Console.WriteLine(topConfig.Vehicle.Paint.MajorColor);
            //Approach 2 (scoped)
            var vehicleSection = configuration.GetSection("Vehicle");
            var vehicle = new Vehicle();
            vehicleSection.Bind(vehicle);
            Console.WriteLine(vehicle.Paint.MajorColor);
        }
    }
