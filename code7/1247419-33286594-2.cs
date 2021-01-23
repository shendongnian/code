      var answer="";
      var validanswers = new [] {"1","2","3"};
      while(!validanswers.Contains(answer))
      {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Eat");
        Console.WriteLine("2. Drink");
        Console.WriteLine("3. Play");
        answer = Console.ReadLine();
        if (answer == "1")
        {
            Console.WriteLine("you picked number 1");
        }
        if (answer == "2")
        {
            Console.WriteLine("You picked number 2");
        }
        if (answer == "3")
        {
            Console.WriteLine("You picked number 3");
        }
      }
