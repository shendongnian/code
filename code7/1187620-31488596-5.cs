    using System;
    
    class Vehicle
    {
        string make, model;
        int year;
    
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
    
        public Vehicle()
        {
            make = model = "Unknown";
            year = 0;
        }
    
        public Vehicle(string make, string model, int year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }
    
        public virtual void GetFromInput()
        {
            Console.Write("Enter the make of vehicle: ");
            Make = Console.ReadLine();
            Console.Write("Enter the model of vehicle: ");
            Model = Console.ReadLine();
            Console.WriteLine("Enter the year of manufacturing for vehicle: ");
            Year = int.Parse(Console.ReadLine());
        }
    
        public override string ToString()
        {
            return string.Format("Vehicle is {0} and of model {1} and is made in {2}.", make, model, year);
        }
    }
