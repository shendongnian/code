    using System.Linq;
    
    static void Main()
    {
        var validInputs = new List<string> {"a", "b", "c", "d"};
    
        string input = Console.ReadLine();
    
        //validate and retry
        while(! validInputs.Contains(input))
        {
            Console.WriteLine("Input was not valid. Please try again.");
            input = Console.ReadLine();
        }
    
        //do something here with the valid input
    }
