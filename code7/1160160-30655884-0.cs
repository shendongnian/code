    public Carvm()
    {
        carLibrary = new CarLib();
        carLibrary.List.Add(new Car("chevy", "corvette", "2016"));
        carLibrary.List.Add(new Car("ford", "gt", "2016"));
        carLibrary.List.Add(new Car("bmw", "m3", "2005"));
        rmCommand = new DeleteCommand(carLibrary);
        touchCommand = new AddCommand(carLibrary);
        NewCar = new Car(); // this line is added
    }
