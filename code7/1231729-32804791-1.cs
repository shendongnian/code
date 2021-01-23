        #region Constructor
        public DemonstrationViewModel()
        {
            InsertCommand = new RelayCommand(ExecuteInsert, CanExecuteInsert);
        }
        #endregion
    
        private void ExecuteInsert()
        {
            EnteredCode += "Clicked! ";
        }
