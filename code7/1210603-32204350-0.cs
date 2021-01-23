    using (EntitiesModel1 context = new EntitiesModel1())
    {
                
        FetchStrategy loadWithRentalOrders = new FetchStrategy();
        loadWithRentalOrders.LoadWith<Car>(car => car.RentalOrders);
        context.FetchStrategy = loadWithRentalOrders;
        Car firstCar = context.Cars.First();
        context.Log = new StringWriter();
        List<RentalOrder> relatedOrders = firstCar.RentalOrders.ToList();
        //should be empty
        string executedScript = context.Log.ToString();
    }
