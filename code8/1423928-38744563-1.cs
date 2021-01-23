    public abstract class BaseChild<T> : MyInterface<T>
    {
        protected BaseChild()
        {
            if (typeof(T) != this.GetType())
            {
                throw new InvalidOperationException(string.Format("Type {0} is not supported as valid type parameter for type {1}", typeof(T).Name, this.GetType().Name));
            }
        }
    }
    
    public class ChildA<T> : BaseChild<T>
    {
    }
    // Bang! throws
    var instance = new ChildA<int>(); 
