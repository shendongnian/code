    public static class AppCache
    {
        static AppCache()
        {
             _mySubject = new Subject<MyObject>();
        }
        private static void NotifyMyObjectChanged(MyObject object)
        {
            _mySubject.OnNext(object);
        }
        public static IObservable<MyObject> MyObjectsObservable 
        { 
            get { return _mySubject; }
        }
    }
    
    public class MyViewModel : ViewModelBase
    {            
         MyViewModel()
         {
              _subscription = AppCache.MyObjectsObservable.
                  .Where(x => x == value)
                  .Subscribe (HandleMyObjectChanged);
         }
    
         private void HandleMyObjectChanged(MyObject object)
         {
            ... do work here ....
         }
    
         public void Dispose()
         {
             _subscription.Dispose();
         }
    }
