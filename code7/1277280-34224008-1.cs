    public class Cars
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string allowed { get; set; }
    }
    var notAllowedModels = GetNotAllowedModels().ToDictionary(x => x); // using dictionary to improve the performance
    foreach(var carGroup in cars.GroupBy(car => car.model)) // cars is a List<Car>
    {
        if (notAllowedModels.ContainsKey(carGroup.Key))
            foreach(var c in carGroup)
                c.allowed = "No";
        else
            foreach(var c in carGroup)
                c.allowed = "Yes";
    }
