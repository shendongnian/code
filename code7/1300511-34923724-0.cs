    private List<Car> Cars
    {
        get
        {
            lock (lockObject)
            {
                return cars ?? (cars = Lockup(..));
            }
        }
    }
