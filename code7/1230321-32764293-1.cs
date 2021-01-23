    // do not re-create Random
    private static Random rnd = new Random();
    ...
    Console.WriteLine("Do you want to play a game of dices with me to win some gold?");
    Console.WriteLine("You can lose 1 gold or you can win 1.1 gold.");
    
    while (goldLeft >= 1.0) { // you must have enough gold if you want to play 
      Console.WriteLine("Wanna play? y or n");
    
      string answer = Console.ReadLine();
    
      if (answer.Equals("n")) {
        Console.WriteLine("That is a safe choice.");
        break;
      }
      else if (!answer.Equals("y")) {
        Console.WriteLine("Since that is not a good answer, I will not play with you");
        break;
      }
      
      // Case "y" here
      int playerRoll = rnd.Next(1, 7);
      int shopRoll = rnd.Next(1, 7);  
      if (playerRoll > shopRoll) {
        goldLeft += 1.1;
        Console.WriteLine("You won 1.1 gold, therefore you now have " + goldLeft + " gold");
      }
      else if (playerRoll < shopRoll) {
        goldLeft -= 1.0;
        Console.WriteLine("You lost 1 gold, therefore you now have " + goldLeft + " gold");
      }
      else {
        Console.WriteLine("That is a draw. Seems that we are both lucky");
      }  
    }
