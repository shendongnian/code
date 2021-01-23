    public interface IFruit
    {
        IFruit GetSeedless();
    }
    public abstract class Fruit<T> : IFruit where T : Fruit<T>
    {
        public abstract T GetSeedless();
        IFruit IFruit.GetSeedless()
        {
            return GetSeedless();
        }
    }
