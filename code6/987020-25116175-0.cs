    class Program
    {
        static void Main(string[] args)
        {
            int results = 0;
 
            Console.WriteLine("how old are you?");
            //int.TryParse(Console.ReadLine(), out results); <-- remove this
            if (int.TryParse (Console.ReadLine(), out results))
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("not an integer");
            }
            
            Console.ReadLine();
        }
    }
