    class Car
    {
        private int Speed = 0;
        private double Temp = 0.0;
        public void setSpeed(int value)
        {
            this.Speed = value;
        }
        public int getSpeed()
        {
            return Speed;
        }
        public void setTemp(double value)
        {
            this.Temp = value;
        }
        public double getTemp()
        {
            return Temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.setSpeed(50);
            car.setTemp(20.50);
            Console.WriteLine("Speed = " + car.getSpeed());
            Console.WriteLine("Temp = " + car.getTemp());
        }
    }
