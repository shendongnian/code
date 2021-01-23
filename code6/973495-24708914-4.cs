    public class DocViewModel : INotifyPropertyChanged
    {
        public DocViewModel()
        {
            this.list = new BindingList<DocView>();
            this.list.ListChanged += list_ListChanged;
        }
    
        void list_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged("Total");
            OnPropertyChanged("Count");
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private BindingList<DocView> list;
    
        public BindingList<DocView> List
        {
            get { return list; }
            set
            {
                list = value;
                OnPropertyChanged("List");
            }
        }
    
        public decimal Total
        {
            get { return list.Sum(x => x.Price); }
        }
    
        private void OnPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public int Count
        {
            get { return list.Count; }
        }
    }
