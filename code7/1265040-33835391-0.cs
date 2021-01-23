    namespace CardGame
    {
        class Dealer
        {
            static void Main(string[] args)
            {
                string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };
                string[] specials = { "Jack", "Queen", "King", "Ace" };
    
                // Two dimensional arrays - I believe this is what you want to achieve, run the application 
                string[,] hand = new string[5,5];
    
                Console.WriteLine("Please enter the number of players:");
    
                int playerCount = Int32.Parse(Console.ReadLine());
    
                for (int currentPlayer = 0; currentPlayer < playerCount; currentPlayer++)
                {
                    Random rand = new Random();
                    for (int cardNumber = 0; cardNumber < 5; cardNumber++)
                    {
                        string card;
    
                        int mode = rand.Next(0, 2);
                        if (mode == 1) // Numeric card...
                        {
                            card = rand.Next(2, 10).ToString();
                        }
                        else // Face card or ace...
                        {
                            card = specials[rand.Next(0, 4)];
                        }
                        hand[currentPlayer, cardNumber] = card += " of " + suits[rand.Next(0, 3)];
                        Console.WriteLine(card += " of " + suits[rand.Next(0, 3)]);
    
                        //Result
                        Console.WriteLine("Result: {0}", hand[currentPlayer, cardNumber]);
                        
                    }
                }
                Console.ReadLine();
            }
        }
    }
