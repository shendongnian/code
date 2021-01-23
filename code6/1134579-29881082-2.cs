    public ObservableCollection<Categories> groupParentList = null;
    public virtual ObservableCollection<Categories> GroupParentList
    {
        get 
        {
            if (groupParentList == null)
                groupParentList = new ObservableCollection<Categories>();
            return groupParentList; 
        }
    }
  
