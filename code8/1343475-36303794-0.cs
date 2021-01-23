    public Class ItemModel: INotifyPropertyChanged
    {
    // implement  INotifyPropertyChanged interface
    
        public ItemModel()
        {
            ToggleCommand = new Command(CmdToggle);
        }
    
        private void CmdToggle()
        {
            IsSelected = !IsSelected;
        }
    
        public string Name
        {
            get;
            set; //call OnPropertyChanged
        }
    
        public bool IsSelected
        {
            get;
            set; //call OnPropertyChanged
        }
    
        public ICommand ToggleCommand{get;private set;}
    
    }
    
