    public class MyClass : INotifyPropertyChanged
    {
		#region INotifyPropertyChanged
		 
		// ....
        
		#endregion
		
		#region Data Members
		 
		private ICommand _resetCommand;
		private string _newName;
        
		#endregion
		
		#region Data Members
		 
		public ICommand ResetCommand
        {
            get
            {
                if (_restNewCCommand == null)
                    _resCommand = new DelegateCommand(resetCommand, canResetCommand);
                return _resetCommand;
            }
        }
		public string NewName
        {
            get
            {
                return _newName;
            }
            set
            {
                _newName = value;
                OnPropertyChanged("NewName");
            }
        }
        
		#endregion
		
		#region Commands Callbacks
		
		private void resetCommand(object obj)
        {
           //Reset inputs
            NewName = String.Empty;
        }
		
		private bool canResetCommand(object obj)
        {
            return true;
        }
		
		#endregion
	}
	
