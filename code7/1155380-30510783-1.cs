    public class AutoStubbed<T> where T:class
    {
      private WeakReference<T> _reference;
      private T _stub;
      private readonly Func<T> _stubFactory;
      public AutoStubbed(T value, T stub)
      {
        _reference = new WeakReference<T>(value);
        _stub = stub;
      }
      public AutoStubbed(T value, Func<T> factory)
      {
        _reference = new WeakReference<T>(value);
        _stubFactory = factory;
      }
      public T Target
      {
        get
        {
          T ret;
          if(_reference.TryGetTarget(out ret))
            return ret;
          if(_stub == null && _stubFactory != null)
            _stub = _stubFactory();
          return _stub;
        }
      }
    }
