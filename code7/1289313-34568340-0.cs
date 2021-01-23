    public interface ILogger
    {
        void Log(string text);
    }
    public interface IListViewLogger : ILogger
    {
        void SetListViewReference(ListView listview);
    }
    public class ListViewLogger : IListViewLogger
    {
        //...
    }
