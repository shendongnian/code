    public ObservableCollection<MyEntity> MySelectionCollection {get;set;}
    public ObservableCollection<MyEntity> MyQuantityCollection {get;set;}
    public DelegateCommand<IList> MyAddCommand {get;set;}
    private void MyAddCommandExecute(IList items)
    {
      //remove from MySelectionCollection 
      //add to MyQuantityCollection 
    }
