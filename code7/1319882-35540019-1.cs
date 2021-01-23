    class Car : Vehicle
    {
        private static object sync = new object();
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
            lock (sync)
            {
             this.carID++;
            }
        }
    }
