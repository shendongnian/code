    public ObservableCollection<PreInvoice> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                Total = Convert.ToString(Collection.Sum(t => t.totalPrice));
                /*or if the above code is not working
                collection=Collection.Sum(t => t.totalPrice));
                */
                OnPropertyChanged("Collection");
            }
        }
