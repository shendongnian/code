    //Accept user input
    Console.WriteLine("Hello, Pick Heads or Tails:");
    var userInput = Console.ReadLine();
    
    //Create and flip the coin
    var rng = new Random();
    var coin = (CoinSide)rng.Next(0, 2);
    //Compare input to coin
    if (coin.ToString() == userInput)
        Console.WriteLine("You picked Right! {0}! YOU WIN!", coin);
    else
        Console.WriteLine("You picked Wrong! it was... {0}", coin);
