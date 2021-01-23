        public static void saveCar(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                Console.WriteLine(vehicle.ID);
                if (vehicle is Car)
                {
                    var car = vehicle as Car;
                    Console.WriteLine(car.Name);
                }
            }
        }
