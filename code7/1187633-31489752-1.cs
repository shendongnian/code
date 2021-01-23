    using System;
    public namespace CodeSpace {
     public class Vehicle { 
      public Vehicle(Type type, string make, string model) {
       Model = model;
       Make = make;
       Type = type;
      }
      public Type VehicleType { get; private set; }
      public string Make { get; set; } 
      public string Model { get; set; } 
     }
     public class Airplane : Vehicle {
      public class Airplane(string make, string model) : base(typeof(Airplane), make, model) {
      }
     }
     public class Boat : Vehicle {
      public class Boat(string make, string model) : base(typeof(Boat), make, model) {
      }
     }
     public class Car : Vehicle {
      public class Car(string make, string model) : base(typeof(Car), make, model) {
      }
     }
     class Program {
     public static void Main(params string[] args ) {       var vehicles = new List<Vehicle>();
      vehicle.Add(new Boat("Canoe", "X2") as Vehicle);
      vehicle.Add(new Boat("Raft", "A") as Vehicle);
      vehicle.Add(new Car("Ford", "T") as Vehicle);
      vehicle.Add(new Airplane("BMW", "Idk") as Vehicle); 
      foreach(var v in vehicles) { 
       Console.WriteLine(v.Type.FullName);
      }
     }
    }
