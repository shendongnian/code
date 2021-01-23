    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "BMW";      
            Console.WriteLine(myCar.FormatMe());
        }
    }
    class Car
    {
        public string Make { get; set; }
        public string FormatMe()
        {
            return string.Format("Make: {0}", this.Make);
        }
    }
