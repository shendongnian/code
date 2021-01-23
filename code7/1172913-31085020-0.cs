     public class ViewModelExample : INotifyPropertyChanged
     {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                RaisePropertyChanged("Count");
            }
        }
        private ObservableCollection<String> _myObservableCollection;
        public ObservableCollection<String> MyObservableCollection
        {
            get
            {
                return _myObservableCollection;
            }
            set
            {
                _myObservableCollection = value;
                RaisePropertyChanged("MyObservableCollection");
            }
        }
        public ViewModelExample()
        {
            this.MyObservableCollection = new ObservableCollection<String>();
            this.MyObservableCollection.CollectionChanged += this.OnCollectionChanged;
            this.Count = MyObservableCollection.Count;
            for(int j=0;j<20;j++)
            {
                this.MyObservableCollection.Add("SOMETHING HERE");
            }
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems!=null)
            {
               this.Count+=e.NewItems.Count;
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
