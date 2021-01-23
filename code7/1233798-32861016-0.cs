    public class MyService
    {
        static MyService()
        {
             WouldBeNice = typeof(MyService).Namespace;
        }
        private static readonly string WouldBeNice;
    }
