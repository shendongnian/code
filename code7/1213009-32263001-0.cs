    public class CustomItemsCollection : ObservableCollection<ItemViewModel>
    {
        public CustomItemsCollection(IEnumerable<ItemViewModel> items)
            : base(items) { }
    
       // your other code here
    }
