    public ObservableCollection<ListStruct> Items { get; set; }
    public ObservableCollection<ListStruct> ItemsWhereFavouriteTrue 
    { 
       get
       {
           return Items.Where(i=>i.favourite == true);
       }
    }
    public ObservableCollection<ListStruct> ItemsWhereFavouriteFalse 
    { 
       get
       {
           return Items.Where(i=>i.favourite == false);
       }
    }
