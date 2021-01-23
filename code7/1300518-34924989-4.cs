    if (cars == null)
    {
      lock(LockObject)
      {
        if (cars == null)
        {
          cars = Lookup(..).RemoveAll(car => car.IsBroken());
        }
      }
    }
    return cars;
