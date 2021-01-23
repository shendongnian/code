    bool continue = true;
    do {
        Console.WriteLine("Do you want to play a game of dices with me to win some gold?");
            Console.WriteLine("You can lose 1 gold or you can win 1.1 gold.");
            Console.WriteLine("Wanna play? y or n");
            var diceAnswer = Console.ReadLine();
            switch (diceAnswer)
            {
                case "y":
                    continue = true;
                    Random rnd = new Random();
                    int playerRoll = rnd.Next(1, 7);
                    Console.WriteLine("You rolled {0}", playerRoll);
                    int shopRoll = rnd.Next(1, 7);
                    Console.WriteLine("I rolled {0}", shopRoll);
                    if (playerRoll > shopRoll)
                    {
                        goldLeft += 1.1;
                        Console.WriteLine("You won 1.1 gold, therefore you now have " + goldLeft + " gold");
                    }
                    else if (playerRoll < shopRoll)
                    {
                        goldLeft--;
                        Console.WriteLine("You lost 1 gold, therefore you now have " + goldLeft + " gold");
                    }
                    else
                    {
                        Console.WriteLine("That is a draw. Seems that we are both lucky");
                    }
                    break;
                case "n":
                    continue = false;
                    Console.WriteLine("That is a safe choice.");
                    break;
                default :
                    continue = false;
                    Console.WriteLine("Since that is not a good answer, I will not play with you");
                    break;
            }
    } while (continue);
