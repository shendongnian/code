    public ObservableCollection<ListStruct> Items { get; set; }
    public ObservableCollection<ListStruct> ItemsWhereFavouriteTrue 
    { 
       get
       {
           return new ObservableCollection<ListStruct>( Items.Where(i=>i.favourite == true).tolist());
       }
    }
    public ObservableCollection<ListStruct> ItemsWhereFavouriteFalse 
    { 
       get
       {
           return new ObservableCollection<ListStruct>( Items.Where(i=>i.favourite == false).tolist());
       }
    }
