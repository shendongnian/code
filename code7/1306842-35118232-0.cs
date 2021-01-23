    public class Car
    { 
         public Engine Engine;
         public List<Tire> Tires;
    }
    public class Engine
    {
         public string Type;
         public string Cylinder;
         public class Turbo
         {
              public string Name;
              public string Power;
              public void CalculatePower()
              {
              }
         }
    }
    public class Tire
    {
    }
