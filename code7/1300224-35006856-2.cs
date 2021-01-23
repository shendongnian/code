    public class UwpViewModel : INotifyPropertyChanged
    {
        public UwpViewModel()
        {
            _groupingCollection = new ObservableGroupingCollection<string, Contact>(new Cache().Contacts);
            _groupingCollection.ArrangeItems(new StateSorter(), (x => x.State));
            NotifyPropertyChanged("GroupedContacts");    
        }
    
        ObservableGroupingCollection<string, Contact> _groupingCollection;
        public ObservableCollection<Grouping<string, Contact>> GroupedContacts 
        {
            get
            {
                return _groupingCollection.Items;
            }
        }
    
        // swap grouping commands
    
        private void GroupByState()
        {
            _groupingCollection.ArrangeItems(new StateSorter(), (x => x.State));
            NotifyPropertyChanged("GroupedContacts");
        }
    
        private void GroupByName()
        {
            _groupingCollection.ArrangeItems(new NameSorter(), (x => x.LastName.First().ToString()));
            NotifyPropertyChanged("GroupedContacts");
        }
    }
