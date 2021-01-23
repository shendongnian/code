    public static void Main()
    {
         Random r = new Random ();
         string again;
         do {
             PlayOneGame( r.Next(1, 1001) );
             Console.WriteLine("Play again?");
             again = Console.ReadLine();
         } while (!again.ToLower().StartsWith('n'));
    }
    public static void PlayOneGame(int rannum)
    {
        Console.Clear ();
        Console.ForegroundColor = ConsoleColor.Green;
        int input;
        Console.WriteLine ("Guess the number!");
        game:
        input = Convert.ToInt32 (Console.ReadLine ());
        if (input == rannum) 
        {
            Console.WriteLine ("Congrats!");
            return;  // goes back to the caller, Main, but without using goto
        } 
        else if (input <= rannum)
        {
            Console.WriteLine ("Guess higher!");
            goto game;
        } 
        else if (input >= rannum)
        {   Console.WriteLine ("Guess lower!");
            goto game;
        }
    }
