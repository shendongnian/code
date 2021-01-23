    public static class AppCache
    {
        public static IObservable<MyObject> MyObjectsObservable { get; }
    }
    
    public class MyViewModel : ViewModelBase
    {         
    
         private void AddMyObject()
         {
              // add object to collection in AppCache, which should then notify all subs that the value has changed
         }
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
