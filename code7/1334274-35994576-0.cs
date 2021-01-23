     public class ContentBlockList : ObservableCollection<int>
        {
            public void SomeMethod()
            {
                var handlers = CollectionChanged.GetInvocationList();
    
                foreach (NotifyCollectionChangedEventHandler handler in handlers)
                {
                    CollectionChanged -= handler;
                }
    
                // do stuff here
    
                foreach (NotifyCollectionChangedEventHandler handler in handlers)
                {
                    CollectionChanged += handler;
                }
            }
    
            public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
        }
