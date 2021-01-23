    public class SomeService : ISomeService
    {
        public delegate SomeService Factory(string userName, string password);
    
        public SomeService(IDataProvider dataProvider,
            ILog log,
            string username,
            string password)
        {
            // ..
