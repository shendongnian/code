    class Vehicle
    {
        protected static int FakeID = 1;
    }
    
    class Car : Vehicle
    {
        public string brand { get; set; }
        public string type { get; set; }
        public int maxSpeed { get; set; }
        public double price { get; set; }
        public int carID { get; set; }
    
        public Car(string _brand, string _type, int _maxspeed, double _price)
        {
            this.brand = _brand;
            this.type = _type;
            this.maxSpeed = _maxspeed;
            this.price = _price;
            this.carID = base.FakeID++;;
    
        }
    }
    void Main()
    {
        Car a = new Car("xyz", "Auto", 120, 12000);
        Car b = new Car("kwx", "Moto", 180, 8000);
        
        Console.WriteLine(a.carID);
        Console.WriteLine(b.carID);
    }
