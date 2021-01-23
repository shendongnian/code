    static void Main(string[] args)
    {
        IPackOfCards cards = PackOfCardsCreator.Create();
        Console.WriteLine(cards.Count);
        ICard c = cards.TakeCardFromTopOfPack();
        Console.WriteLine(c.toString());
    }
