    class Program
    {
        // Properties
        public int Number {get; set;}
        // Methods
        public static void Main(string[] args)
        { 
            
            Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ditt nummer är: " + Number);
            Console.ReadKey();
        }
    }
