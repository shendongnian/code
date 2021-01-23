    namespace Test.Database
    {
        public interface IEntity<T>
        {
             T KeyValue { get; set; }
        }
    }
