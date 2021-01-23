    class Program
    {
        static void Main(string[] args)
        {
            Car Ford = new Car();
            Car Toyota = new Car();
            Motorcycle Kawasaki = new Motorcycle();
            Bike Zebra = new Bike();
            List<Vehicle> Garage = new List<Vehicle>();
            Garage.Add(Ford);
            Garage.Add(Toyota);
            Garage.Add(Kawasaki);
            Garage.Add(Zebra);
            Class1<Vehicle> c1 = new Class1<Vehicle>(Garage);
        }        
    }
     class Bike : Vehicle
    {
    }
     class Car : Vehicle
    {
    }
     class Motorcycle : Vehicle
    {
    }
     class Vehicle
    {
    }
    class Class1<T> 
    {
        public Class1(List<T> obj)
        {
            foreach (var item in obj)
            {
            }            
        }
    }
