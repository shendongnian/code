    public static class AppCache
    {
    
        ObservableCollection<MyObject> MyObjects { get; set; }
    
        public static IObservable<ObservableCollection<MyObject>> MyObjectsObservable { get; private set; }
    
        private static async void GetMyObjectsAsync()
        {
            await Task.Run(() => GetMyObjects());
    
            NotifyMyObjectChanged() // this basically just replaces the mediator
        }
    
        private static GetMyObjects()
        {                   
            ...         
            MyObjects = result;
            MyObjectsObservable = Observable.FromEventPattern(h=>MyObjects.CollectionChanged += h, h=>MyObjects.CollectionChanged -= h);
        }
    
        static AppCache()
        {
            GetMyObjectsAsync();
        }    
    
    }
