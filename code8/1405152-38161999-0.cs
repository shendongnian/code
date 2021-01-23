    abstract class Car 
    {
      public abstract double MaximumSpeed { get; } 
    }
    class Minivan : Car 
    {
      public override double MaximumSpeed { get { return 100.0; } }
    }
