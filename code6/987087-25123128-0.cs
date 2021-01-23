    public class House
    {
        public string Color { get; set; }
        public double SquareFeet { get; set; }
        public override string ToString()
        {
            return "Color: " + Color + ", Sq. Ft.:" + SquareFeet;
        }
    }
    public class Car
    {
        public string Color { get; set; }
        public double EngineSize { get; set; }
        public override string ToString()
        {
            return "Color: " + Color + ", cc: " + EngineSize;
        }
    }
    public class ValuesController : ApiController
    {
        public string Get([FromUri] bool house, [FromUri] House model)
        {
            return model.ToString();
        }
        public string Get([FromUri] bool car, [FromUri] Car model)
        {
            return model.ToString();
        }
    }
