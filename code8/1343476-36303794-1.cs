    public Class PageViewModel: INotifyPropertyChanged
    {
    
        public List<ItemModel> Items
        {
            get;
            set; //call OnPropertyChanged
        } 
    }
    
