    public interface IMyEntitiesFactory
    {
        MyEntities Create();
    }
    public class MyEntitiesFactory : IMyEntitiesFactory
    {
        MyEntities IMyEntitiesFactory.Create()
        {
            return new MyEntities();
        }
    }
    // For use with unit tests; e.g. pass a mock object to the constructor.
    public class TestMyEntitiesFactory : IMyEntitiesFactory
    {
        private readonly MyEntities _value;
        public TestMyEntitiesFactory(MyEntities value)
        {
            _value = value;
        }
        MyEntities IMyEntitiesFactory.Create()
        {
            return _value;
        }
    }
