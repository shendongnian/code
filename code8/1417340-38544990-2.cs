    public class ViewModel
    {
        public ViewModel()
        {
            CustomCFactors.CollectionChanged += (s, e) => {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (CustomCFactorItem item in e.NewItems)
                            item.PropertyChanged += BackupLogicEventHandler;
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (CustomCFactorItem item in e.OldItems)
                            item.PropertyChanged -= BackupLogicEventHandler;
                        break;
                }
            };
            for (int i = 0; i < 10; ++i)
            {
                CustomCFactors.Add(new CustomCFactorItem("one", "two", "three"));
            }
            ExecuteBackupLogic();
            
        }
        public ObservableCollection<CustomCFactorItem> CustomCFactors { get; set; } = new ObservableCollection<CustomCFactorItem>();
        public void BackupLogicEventHandler(object sender, PropertyChangedEventArgs e){
            ExecuteBackupLogic();
        }
        public void ExecuteBackupLogic()
        {
            Console.WriteLine("changed");
        }
    }
