    if (cars == null)
    {
      var tempCars = Lookup(..).RemoveAll(car => car.IsBroken());
      lock(LockObject)
      {
        if (cars == null)
        {
          cars = tempCars;
        }
      }
    }
    return cars;
