    Random rd = new Random();
    int comp = rd.Next(10); // Store you random number before the loop
    int guess = 0;
    int trylimit = 3;
    int round = 0;
    
    while (round < trylimit)
        {
            Console.WriteLine("guess a number 0-10");
    
            guess = int.Parse(Console.ReadLine());
    
            if (guess == comp)
                {
                    Console.WriteLine("congratz!! u won!!");
                    Console.WriteLine("press any key to exit");
                    break;
                }
            else if (guess > comp)
                Console.WriteLine("your guess is greater than my number, yow!");
            else if (guess < comp)
                Console.WriteLine("your guess is lower than my number, yow!");
    
                round++;
        }
    Console.WriteLine("loser!!" + "My number was:" + comp + "\n");
    Console.ReadLine();
