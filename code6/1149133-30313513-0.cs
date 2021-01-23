    public class Car
    {
        public List<Part> ListOfParts = new List<Part>();
    
        // ...
    }
    public abstract class Part
    {
        // ...
    }
    
    public class Tire : Part
    {
        // ...
    }
    // Main ...
    Car myCar = new Car ();
    Tire myTire = new Tire ();
    
    myCar.ListOfParts.Add ( myTire );
