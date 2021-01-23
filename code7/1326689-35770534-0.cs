    public class Controller
    {
        public Controller()
        {
            this.Config = new Configuration();
        }
        public Configuration Config { get; set; }
    }
    public class Configuration
    {
        public string Name { get; set; }
        public string BusinessID { get; set; }
        public string Address { get; set; }
    }
