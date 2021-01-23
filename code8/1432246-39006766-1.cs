    class MyObject : INotifyPropertyChanged
    {
        private string _a;
        public event PropertyChangedEventHandler PropertyChanged;
        public string A
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Pagey : ContentPage
    {
        private ObservableCollection<MyObject> c = new ObservableCollection<MyObject>();
		// somwhere in your code 
		c.CollectionChanged += OnCollectionChanged;
		
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.NewItems != null)
            {
                foreach (var item in args.NewItems.Cast<MyObject>())
                {
                    item.PropertyChanged += OnChanged;
                }
            }
            
            if(args.OldItems != null)
            {
                foreach (var item in args.OldItems.Cast<MyObject>())
                {
                    item.PropertyChanged -= OnChanged;
                }
            }
            Redraw();
        }
        private void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            Redraw();
        }
        private void Redraw()
        {
            
        }
    }
