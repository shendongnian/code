     public static void LoadCards()
     {
         //Random initialized outside of the foreach loop
         Random r = new Random();
         Deck deck = new Deck();
         for (int i = 0; i < 24; i++)
         {
             YourDeck.Add(deck.CardNames[r.Next(0, 14)]);
         }
      }
