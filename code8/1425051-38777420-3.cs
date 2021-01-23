     private ObservableCollection<yourClass>_ProgressList;
        public ObservableCollection<yourClass> ProgressList
        {
            get { return _ProgressList; }
            set
            {
                _ProgressList= value;                
                Progress = ProgressList.Where(x => x.Done).Count();
                NotifyPropertyChanged();
            }
        }     
