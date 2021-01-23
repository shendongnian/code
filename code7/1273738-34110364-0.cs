    public static void LoadCards()
    {
        Deck deck = new Deck();
        Random r = new Random();
        for (int i = 0; i < 24; i++)
        {
            YourDeck.Add(deck.CardNames[r.Next(0, 14)]);
        }
    }
