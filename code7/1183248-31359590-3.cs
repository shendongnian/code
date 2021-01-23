    static void Main(string[] args)
    {
        PackOfCards cards = PackOfCards.Create();
        Console.WriteLine(cards.Count);
        ICard c = cards.TakeCardFromTopOfPack();
        Console.WriteLine(c);
    }
