    public ObservableCollection<CustomItem> CustomItems
    {
         get { return _customItems; }
         private set
         {
            if (Equals(value, _customItems)) return;                
            _customItems= value;
            RaisePropertyChanged("CustomItems");
          }
    }
        
    public CustomItem SelectedCustomItem
    {
      get { return _selectedCustomItem }
      private set
       {
         if (Equals(value, _selectedCustomItem )) return;
         try
         {
            DoSomething(value); 
            //if you need the index and not the model do one way-Binding to the index too
          }
          catch(DataInvalidException e)
          {
            MessageBox.Show(e.message);
           return;
          }
          _selectedCustomItem = value;
          RaisePropertyChanged("SelectedCustomItem");
        }
    }
