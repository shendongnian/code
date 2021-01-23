        private string textField;
        public string TextField
        {
            get { return textField; }
            set
            {
                if (value == textField) return;
                textField = value;
                OnPropertyChanged();
            }
        }
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand ?? (saveCommand = new DelegateCommand(Save)); }
        }
        private void Save()
        {
           // Do your DB transactions here. 
        }
