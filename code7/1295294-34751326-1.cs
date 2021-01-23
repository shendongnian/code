    public interface IPort
    {
        object SomeAction(object data);
    }
    public class Port<T> : IPort
    {
        //[.. all other methods ..]
        object IPort.SomeAction(object data)
        {
            var typedData = (T)data;
            //invoke our typed version.
            return SomeAction(data);
        }
        public T SomeAction(T data)
        {
             // ...
        }
    }
