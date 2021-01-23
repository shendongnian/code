    class Program
    {
        static void Main(string[] args)
        {
            var L = new ListManager();
            L.Add(new Car { Wheels = 4 });
            L.Add(new Car { Wheels = 3 });
            L.Add(new Bike { Pedals = 2 });
            //Prints 2:
            Console.WriteLine(L.Car.Count);
            //Prints 1:
            Console.WriteLine(L.Bikes.Count);
            Console.ReadKey();
        }
    }
