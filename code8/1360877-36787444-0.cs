    class SpecificCarFactory
    {
      public SpecificCarFactory(IList<Battery> batteries, IList<Engine> engines)
      {
        //save batteries etc into local  properties
      }
      public Car GetCar(CarType carType)
      { 
        switch(carType) 
        {  case CarType.Ford: return new Mustang(_engines.First()); }
      }
    }
