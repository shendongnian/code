    static void Main(string[] args)
        {
            const int MAX_FEED_LEVEL = 3; //configure it as per your need
            const int HIGHEST_HUNGER_LEVEL = 0; //0 indicates the Extreme hunger
            int hunger = MAX_FEED_LEVEL, foodLevel = HIGHEST_HUNGER_LEVEL;
            string name = string.Empty;
            char finalChoice = 'N', feedChoice = 'N';
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Good choice, {0}!", name);
            Console.WriteLine();
            do
            {
                Console.WriteLine();
                Console.WriteLine("current hunger level : {0}", hunger);
                if (hunger > 0)
                    Console.WriteLine("You are hungry, {0}", name);
                Console.Write("Press F to feed : ");
                feedChoice = (char)Console.ReadKey(true).Key;
                if (feedChoice == 'F' || feedChoice == 'f')
                {
                    if (foodLevel <= MAX_FEED_LEVEL && hunger > HIGHEST_HUNGER_LEVEL)
                    {
                        hunger = hunger - 1; //decrementing hunger by 1 units
                        foodLevel += 1; //incrementing food level
                        Console.WriteLine();
                        Console.WriteLine("Feeded!");
                        Console.WriteLine("Current Food Level : {0}", foodLevel);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Well Done! {0} you're no more hungry!", name);
                        goto END_OF_PLAY;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.Write("You chose not to feed !");
                }
                Console.WriteLine();
                Console.Write("want to continue the game ? (Y(YES) N(NO))");
                finalChoice = (char)Console.ReadKey(true).Key;
            } while (finalChoice == 'Y' || finalChoice == 'y');
        END_OF_PLAY:
            Console.WriteLine();
            Console.Write("===GAME OVER===");
            Console.ReadKey();
        }
