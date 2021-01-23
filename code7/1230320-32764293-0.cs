    Console.WriteLine("Do you want to play a game of dices with me to win some gold?");
    Console.WriteLine("You can lose 1 gold or you can win 1.1 gold.");
    
    while (goldLeft >= 1.0) {
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
      
      //TODO: implement case "y" here
    }
