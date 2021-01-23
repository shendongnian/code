    class ListViewItemViewMOdel:INotifyPropertyChanged
    {
            public string Name
            {
                return "SomeString";
            }
            private ObservableCollection<ListViewItemViewModel> _variants;
        
            public ObservableCollection<ListViewItemViewModel> Variants
            {
                get
                {
                    return _variants;
                }
            }
    
            public ListViewItemViewMOdel()
            {
                _variants.CollectionChanged+=_variants_CollectionChanged;
            }
    
            void _variants_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
     	        OnPropertyChanged("Variants");
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string prop)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
    }
