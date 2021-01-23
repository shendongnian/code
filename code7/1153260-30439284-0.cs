    public interface ICommon<T>
    {
        T Field { get; set; }
    }
    public class GenericClass<T>
    {
        public ICommon<T> SomeOperation(ICommon<T> x)
        {
            // do your stuff
        }
    }
