    public interface INavigationRequest<out T>
    {
        T Screen { get; }
        void Go();
    }
