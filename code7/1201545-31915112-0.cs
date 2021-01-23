    public class Order : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Order(int id)
        {
            DBDataContext dbContext = new DBDataContext();
            DCAPPDBDataContext dbContext2 = new DCAPPDBDataContext();
            var itemsSource = dbContext.SP_Get_ItemList(id);
            var additionals = dbContext2.SP_Get_AdditionalsList(id);
            Id = id;
            Name = itemsSource.name;
            Quantity = itemsSource.quantity;
            // other properties ...
            Additionals = new ObservableCollection<string>();
            foreach (var item in additionals)
            {
                Additionals.Add(item);
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        // define other properties e.g. Name, Quantity, Price, etc.
        // the same way as Id.
       
        public ObservableCollection<string> Additionals {get;set;}
    }
