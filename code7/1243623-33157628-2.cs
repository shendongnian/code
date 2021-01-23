    static public bool PlayAgain()
    {
        while(true) // Continue asking until a correct answer is given.
        {
            Console.Write("Do you want to play again [Y/N]?");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
                 return true;
            if (answer == "N")
                 return false;
        }
    }
