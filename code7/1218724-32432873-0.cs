    public interface ILogger
    {
        void Log(string message);
    }
    public interface IDataConnector<T>
    {
        IList<T> ReadList(Predicate<T> matches);
        T ReadItem(Predicate<T> match);
    }
