      List<Car> Car = new List<Car>() {... }
      ...
      var factories = Car
        .Where(car => IsCarSpecific(car))
        .SelectMany(car => car.Factories
           .Select(factory => factory.Werk));
        // .Distinct(); // in case you want distinct factories
        // .ToList(); if you want materiazlize into List<Factory>
