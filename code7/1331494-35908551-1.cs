        public AlarmsViewModel()
        {
            
            if (_alarmItemRepository == null)
                _alarmItemRepository = new AlarmItemRepository();
            this.Collection = new ObservableCollection<Model.AlarmItem>(_alarmItemRepository.GetAlarmItems());
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Collection);
            collectionView.SortDescriptions.Add(new SortDescription("NextSpawn", ListSortDirection.Ascending));
            var view = (ICollectionViewLiveShaping)CollectionViewSource.GetDefaultView(this.Collection);
            view.IsLiveSorting = true;
            //  Bind to the sorting event of the datagrid in the AlarmView
            AlarmsView.View.dgAlarms.Sorting += DgAlarms_Sorting;
            //  Other code
            // ...
            // ...
           
        }
