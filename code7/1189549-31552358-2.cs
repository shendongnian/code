    class Program
    {
        public int number; // can be accessed by other functions/methods
        public int othernumber ; // can be accessed by other functions/methods
        public int sum;
        public void detail()
        {
            Console.WriteLine("Multiplication Calculator.");
            Console.WriteLine("Number 1: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            Console.WriteLine("Number 2: ");
            string inputa = Console.ReadLine();
            othernumber = int.Parse(inputa);
        }
