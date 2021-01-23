    public static void Main()
    {
        var deck = new Deck();
        foreach (var card in deck.Cards)
        {
            Console.WriteLine(card.ToString());
        }
    }
