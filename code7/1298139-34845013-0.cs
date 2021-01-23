     if (coin == Convert.ToInt32(CoinSides.Heads) && userInput == CoinSides.Heads.ToString("D"))
            {
                Console.WriteLine("You picked Right! Heads! YOU WIN!");
            }
     else if (coin == Convert.ToInt32(CoinSides.Tails) && userInput == CoinSides.Tails.ToString("D"))
            {
                Console.WriteLine("You picked Right! Tails! YOU WIN!");
            }
     else
            {
                Console.WriteLine("You picked Wrong! it was..." + myString);
            }
