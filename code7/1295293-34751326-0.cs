    public interface IPort
    {
        void SomeAction(object data);
    }
    public class Port<T> : IPort
    {
        //[.. all other methods ..]
        void IPort.SomeAction(object data)
        {
            var typedData = (T)data;
            //call generic methods etc.
        }
    }
