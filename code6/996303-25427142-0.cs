    public interface IPerson
    {
      string name { get; set; }
    }
    public abstract class APerson : IPerson
    {
      public string name { get; set; }
    }
    public class Man : APerson { /* ... */ }
    public class Woman : APerson { /* ... */ }
    public interface ICar
    {
      IPerson driver { get; set; }
    }
    public class Car : ICar
    {
      // This maps to the database
      public virtual APerson driver { get; set; }
      // And this implements the interface
      ICar.driver
      {
        get
        {
          return (IPerson)driver;
        }
        set
        {
          if(!(value is APerson))
            throw new InvalidCastException("driver must inherit from APerson");
          driver = (APerson)value;
        }
      }
    }
