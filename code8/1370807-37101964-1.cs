    public class FastEventHandler<T> : IEventHandler<T>
    {
        // To emphasize that the implementation depends on T
        private void SomeHelperClass<T> helperClass;
    
        public void HandleEvent(object t)
        {
            if (t == null || !Type.Equals(t.GetType(), typeof(T)))
            {
                // We cannot handle the event.
                return;
            }
            T typedValue = Convert(t);
            // Here comes the rest of handling process.
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
    } 
