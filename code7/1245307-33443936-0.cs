       [Export]
    public class FriendDataProvider
    {
        private readonly ExportFactory<IDataService> _dataServiceCreator;
        [ImportingConstructor]
        public FriendDataProvider(ExportFactory<IDataService> dataServiceCreator) // <= DI ERROR
        {
            _dataServiceCreator = dataServiceCreator;
        }
        public void DoSomething()
        {
            using (var service = _dataServiceCreator.CreateExport()) // Factory
            {
                
            }
        }
    }
    [Export(typeof(IDataService))]
    public class DataService : IDataService
    {
        public ClassA GetSomething()
        {
            return new ClassA();
        }
        public void Dispose()
        { }
    }
    public interface IDataService : IDisposable
    {
        ClassA GetSomething();
    }
    public class ClassA
    { }
