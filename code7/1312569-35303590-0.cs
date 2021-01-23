    public interface IBook<TEventArgs> where TEventArgs : EventArgs
    {
        event EventHandler<TEventArgs> PageChanged;
    }
    public class Novel : IBook<EventArgs>
    {
        event EventHandler<EventArgs> PageChanged;
    }
    public class Encyclopedia : IBook<EncyclopediaEventArgs>
    {
        event EventHandler<EncyclopediaEventArgs> PageChanged;
    }
