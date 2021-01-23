    public static void Main(string[] args)
    {
        IEnumerable<string> allowedInputs = new[] {"1", "2", "3"};
        string userInput = "";
        while (!allowedInputs.Contains(userInput))
        {
            Console.WriteLine("Enter 1, 2 or 3");
            userInput = Console.ReadLine();
        }
        int atkChoice = Convert.ToInt32(userInput);
        //Do your if conditions
    }
