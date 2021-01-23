    public class CustomEventArgs<T> where T : A
    {
         private readonly T _instance;
    
         public CustomEventArgs(T instance)
         {
              _instance = instance;
         }
    
         public T Instance { get { return _instance; } }
    }
