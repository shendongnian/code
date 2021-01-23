    if (cars == null)
    {
      lock(LockObject)
      {
         if (cars == null)
         {
            cars = Lookup(..)
            foreach (car in cars.ToList())
             {
               if (car.IsBroken())
               {
                   cars.Remove(car)
               }
             }
          }
       }
    }
    return cars; // Not thread-safe.
