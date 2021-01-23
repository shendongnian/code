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
    
        public Order(SP_Get_ItemListResult itemResult)
        {
            DBDataContext dbContext = new DBDataContext();                
    
             orderItemID = itemResult.orderItemID;
            itemName = itemResult.ItemName;
            quantity = itemResult.quantity;           
            // other properties ...
          var additionals = dbContext.SP_Get_AdditionalsList(orderItemID);
            Additionals = new ObservableCollection<string>();
            foreach (var item in additionals)
            {
                Additionals.Add(item.Additionals);
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
