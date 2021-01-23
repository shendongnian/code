    public static List<Car> Cars;
    public static void GetCars()
    {
        Cars = Enumerable.Range(1,5)
        .Select(i => new Car(i))
        .ToList();
    }
    protected void Application_Start()
    {
        GetCars();
    }
