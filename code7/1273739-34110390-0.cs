     public static void LoadCards()
     {
         Deck deck = new Deck();
         for (int i = 0; i < 24; i++)
         {
             Random r = new Random();
             YourDeck.Add(deck.CardNames[r.Next(0, 14)]);
         }
      }
