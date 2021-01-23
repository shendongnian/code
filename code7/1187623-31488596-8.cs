    using System;
    
    class Boat : Vehicle
    {
        int length;
        string hullType;
        public int Length { get { return length; } set { length = value; } }
        public string HullType { get { return hullType; } set { hullType = value; } }
    
        public Boat() : base()
        {
            length = 0;
            hullType = "Unknown";
        }
    
        public Boat(string make, string model, int year, int length, string hullType) : base(make, model, year)
        {
            this.length = length;
            this.hullType = hullType;
        }
    
        public override void GetFromInput()
        {
            base.GetFromInput();
            Console.Write("Enter the length of the boat: ");
            Length = int.Parse(Console.ReadLine());
            Console.Write("Enter the hull type for the boat: ");
            HullType = Console.ReadLine();
        }
    
        public override string ToString()
        {
            return base.ToString() + string.Format("This vehicle is a boat with length of {0} and hull type of {1}.", Length, HullType);
        }
    }
