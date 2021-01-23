    public class Cars
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string allowed { get; set; }
    }
    var notAllowedModels = GetNotAllowedModels(); // returns a List<String> with model names
    foreach(var carGroup in cars.GroupBy(car => car.model)) // cars is a List<Car>
    {
        if (notAllowedModels.Contains(carGroup.Key))
            foreach(var c in carGroup)
                c.allowed = "No";
        else
            foreach(var c in carGroup)
                c.allowed = "Yes";
    }
