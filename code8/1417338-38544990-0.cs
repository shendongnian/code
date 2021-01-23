    public ViewModel(){
         ExecuteBackupLogic();
         CustomCFactors.CollectionChanged += (s,e) => {
              switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (CustomCFactorItem item in e.NewItems)
                            item.PropertyChanged += BackupLogicEventHandler;
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (ObservableObject item in e.OldItems)
                            item.PropertyChanged -= BackupLogicEventHandler;
                        break;
                }
         };
    }
    
    public ObservableCollection<CustomCFactorItem> CustomCFactors {get;set;}
    
    public event PropertyChangedEventHandler BackupLogicEventHandler(object sender, PropertyChangedEventArgs e){
         ExecuteBackupLogic();
    }
