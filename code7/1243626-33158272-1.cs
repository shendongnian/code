    private static bool PlayGame()
    {
        // Win branch returns true.
        // Loss branch returns false.
    }
This then lets you greatly simplify the Main function allowing it to only handle the menu functionality.
For the actual menu functionality, I tend to prefer do/while loops. You have a bit of an extra stipulation that you only ask after 5 plays, but that's easy enough to deal with.
    static void Main(string[] args)
    {
        int playCount = 0;
        string answer = "Y";
        bool winner;
        do
        {
            winner = PlayGame();
            if(playCount < 5)
            {
                playCount++;
            }
            else
            {
                do
                {
                    Console.Write("Play again? (Y/N): ");
                    answer = Console.ReadLine().ToUpper();
                } while(answer != "Y" && answer != "N");
            }
        } while(!winner && answer == "Y");
        Console.WriteLine("Thanks for playing!");
    }
You could simplify it a bit by moving the test for 5 games into the if conditional with the use of an increment operator. The only issue is if someone plays your game a billion or so times, things might get weird.
    static void Main(string[] args)
    {
        int playCount = 0;
        string answer = "Y";
        bool winner;
        do
        {
            winner = PlayGame();	    
            if(playCount++ > 3)
            {
                do
                {
                    Console.Write("Play again? (Y/N): ");
                    answer = Console.ReadLine().ToUpper();
                } while(answer != "Y" && answer != "N");
            }
        } while(!winner && answer == "Y");
        Console.WriteLine("Thanks for playing!");
    }
