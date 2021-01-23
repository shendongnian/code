    // Commands
        public RelayCommand MoveUpCommand { get; set; }
        public RelayCommand MoveDownCommand { get; set; }
        public RelayCommand UndoCommand { get; set; }
        public RelayCommand RedoCommand { get; set; }
        public RelayCommand ClearCommnand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        // Properties
        private string _modName;
    // setup ModPanel
            ModName = "Something";
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            UndoCommand = new RelayCommand(Undo);
            RedoCommand = new RelayCommand(Redo);
            ClearCommnand = new RelayCommand(Clear);
            RemoveCommand = new RelayCommand(Remove);
    public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string ModName
        {
            get { return _modName; }
            set
            {
                _modName = value;
                OnPropertyChanged();
            }
        }
        public void MoveUp(object obj)
        {
            throw new NotImplementedException();
        }
        public void MoveDown(object obj)
        {
            throw new NotImplementedException();
        }
        public void Undo(object obj)
        {
            throw new NotImplementedException();
        }
        public void Redo(object obj)
        {
            throw new NotImplementedException();
        }
        public void Remove(object obj)
        {
            throw new NotImplementedException();
        }
        public void Clear(object obj)
        {
            throw new NotImplementedException();
        }
        public void PreApply()
        {
            throw new NotImplementedException();
        }
