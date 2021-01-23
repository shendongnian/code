    public class DelegateGenerator<TDelegate, TReturn> 
        : GenBase<TDelegate, TReturn> where TDelegate : class
    {
        public TReturn RunEvent() => runEvent();
    }
    public class DelegateGenerator<TDelegate, TReturn, T> 
        : GenBase<TDelegate, TReturn> where TDelegate : class
    {
        public TReturn RunEvent(T a) => runEvent(a);
    }
    public class DelegateGenerator<TDelegate, TReturn, T1, T2> 
        : GenBase<TDelegate, TReturn> where TDelegate : class
    {
        public TReturn RunEvent(T1 a, T2 b) => runEvent(a, b);
    }
    // etc
    public abstract class GenBase<TDelegate, TReturn> where TDelegate : class
    {
        public TDelegate GenerateDelegate()
        {
            var method = GetType().GetMethod("RunEvent");
            return Delegate.CreateDelegate(typeof(TDelegate), this, method) as TDelegate;
        }
        protected TReturn runEvent(params object[] objs)
        {
            // some code
            return (TReturn)result;
        }
    }
