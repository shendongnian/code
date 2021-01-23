    public class Car
    {
        public string Make {get; set;}
        public string Model {get; set;}
        // additional properties here.
    }
    public static class CarFactory
    {
        public static Car CreateCar(string modelId)
        {
            Car car = new Car();
            // Load the car via whatever mechanism you wish;
            // e.g., web service, database, etc.
            return car;
    }
    Car fordFairlane = CarFactory.CreateCar("57fordFairlane");
