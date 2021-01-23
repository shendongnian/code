    static void Main(string[] args)
    {
        //test data
        var cars = new List<Car>();
        cars.Add(new Car { Brand = "BMW", HorsePower = 100, TopSpeed = 200 });
        cars.Add(new Car { Brand = "VW", HorsePower = 90, TopSpeed = 150 });
        var drivers = new List<Driver>();
        drivers.Add(new Driver { Name = "Prit", Age = 18, Sex = "Male" });
        drivers.Add(new Driver { Name = "Jane", Age = 20, Sex = "Female" });
        RenderOutput(cars);
        Console.WriteLine();
        RenderOutput(drivers);
        Console.ReadLine();
    }
