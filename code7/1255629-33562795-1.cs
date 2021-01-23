        public InvoiceViewModel()
        {
            Collection = new ObservableCollection<PreInvoice>();
            Collection.CollectionChanged += Collection_CollectionChanged;
        }
        void Collection_CollectionChanged(object sender,  System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Total");
        }
