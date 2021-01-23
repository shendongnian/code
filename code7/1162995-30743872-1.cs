    class Program
    {
        static void Main(string[] args)
        {
            var coll = new ObservableCollection<string>();
    
            // TODO: subscribe to an event here
            coll.CollectionChanged += coll_CollectionChanged;
    
            coll.Add("Big Mac");
            coll.Add("Filet 'O Fish");
            coll.Add("Quarter Pounder");
            coll.Add("French Fries");
            coll.Remove("Filet 'O Fish");
    
            Console.ReadKey(true);
        }
    
        static void coll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            List<string> items = new List<string>();
    
            //added items
            if (e.NewItems != null)
                items.AddRange(e.NewItems.OfType<string>());
    
            ///old items
            if (e.OldItems != null)
                items.AddRange(e.OldItems.OfType<string>());
    
            Console.WriteLine(string.Join(", ", items));
        }
    }
