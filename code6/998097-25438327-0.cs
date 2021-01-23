    private ICommand _populateGridCommand;
    public ICommand PopulateGridCommand
    {
       get
       {
          if (_populateGridCommand == null)
          {
             _populateGridCommand = new RelayCommand(() => PopulateGrid());
          }
          return _populateGridCommand;
       }
    }
    public void PopulateGrid()
    {
       PaymentCollection.Clear();
       //load data and then add to the collection
    }
