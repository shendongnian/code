    abstract class Car<TWheel> : ICar where TWheel : IWheel
    {
       string Color { get; set; }
       ICollection<TWheel> Wheels { get; set; }
    
       public Car()
       {
          Wheels = new List<TWheel>();
       }
    }
    class SpecialCar : Car<SpecialWheel> {
        // Whatever
    }
