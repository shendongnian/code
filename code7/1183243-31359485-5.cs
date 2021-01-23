    public interface IPackOfCards : IReadOnlyCollection<ICard>
    {
        void Shuffle ();
        ICard TakeCardFromTopOfPack ();
        public int Count { get; }
    }
    
    public interface IPackOfCardsCreator
    {
        IPackOfCards Create();
    }
    public static class PackOfCardsCreator : IPackOfCardsCreator
    {
        public static IPackOfCards Create()
        {
            return PackOfCards.Create();
        }
    }
