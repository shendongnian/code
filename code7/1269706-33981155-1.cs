    class Calculation
    {
        public double Amount { get; set; }
  
        public double run(double y)
        {
            // No need to start at 1000.
            for(int i = 0; i < 300; i++)
            {
                Amount += y;
            }
            return Amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();
            // pass your variable as a parameter into a class function.
            var y = 30.0;
            Console.WriteLine(calculation.run(y).ToString());
            //  Console.ReadLine(); use control F5 to prevent console window from closing.
        }
    }
