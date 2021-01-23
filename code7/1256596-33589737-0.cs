    // To store common properties and methods, use an abstract class:
    public abstract class Car {
      public string Make {get; set;};
      public string Model {get; set;};
    // The rest of properties
    }
    // To store special data for a particular type of car:
    public class Van: Car
    {
       public string DoorType {get; set;}
       // the rest of properties
    }
    
    public class Truck: Car
    {
    //...
    }
