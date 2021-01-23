    static void Main()
    {
        Random rnd = new Random();
        string guess;
        int yourguess;
        int dice = rnd.Next(1, 7);
        Console.WriteLine("Guess a number between 1 and 6");
        do
        {
            guess = Console.ReadLine();
            yourguess = int.Parse(guess);
            if (yourguess > dice)
            {
                Console.WriteLine("Lower");
            }
            if (yourguess < dice)
            {
                Console.WriteLine("Higher");
            }
            if (yourguess == dice)
            {
                Console.WriteLine("Correct!");
            }
        } while (yourguess != dice)
        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
