    using System;
    
    class Car : Vehicle
    {
        string bodyType;
        public string BodyType { get { return bodyType; } set { bodyType = value; } }
    
        public Car() : base()
        {
            bodyType = "Unknown";
        }
    
        public Car(string make, string model, int year, string bodyType) : base(make, model, year)
        {
            this.bodyType = bodyType;
        }
    
        public override void GetFromInput()
        {
            base.GetFromInput();
            Console.Write("Enter body type for the car: ");
            BodyType = Console.ReadLine();
        }
    
        public override string ToString()
        {
            return base.ToString() + string.Format("This vehicle is a car with body type of {0}.", BodyType);
        }
    }
