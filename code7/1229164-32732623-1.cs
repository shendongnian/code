    public Item SelectedItem1
    {
        get { return _selectedItem1; }
        set
        {            
            _selectedItem1 = value;
            OnPropertyChanged();
            if(value!=null)  //Here is the trick.
                SelectedItem2=null;
            OnPropertyChanged("SelectedItem");
        }
    }
