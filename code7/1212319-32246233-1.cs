        internal class Program
        {
            private static void Main(string[] args)
            {
                var car = new Car
                {
                    Engine = "1234",
                    Wheels = 4,
                    Passengers = new List<Passenger>
                    {
                        new Passenger
                        {
                            Id = 1,
                            Name = "Bhushan"
                        }
                    }
                };
    
                ReflectObject(car);
                Console.ReadKey();
            }
    
