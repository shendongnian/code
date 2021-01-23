    public interface IEventHandler
    {
        void HandleEvent(object value);
    }
    public interface IEventHandler<T> : IEventHandler
    {
        void HandleEvent(T value);
    }
    public abstract class EventHandler<T> : IEventHandler<T>
    {
        public void HandleEvent(object value)
        {
            if (value == null || !Type.Equals(value.GetType(), typeof(T)))
            {
                return;
            }
            HandleEvent(Convert(value));
        }
        private T Convert(object value)
        {
            try
            {
                return (T)value;
            }
            catch
            {
                return default(T);
            }
        }
        public abstract void HandleEvent(T value);
    }
    public class FastEventHandler<T> : EventHandler<T>
    {
        public override void HandleEvent(T value)
        {
            throw new NotImplementedException();
        }
    }
