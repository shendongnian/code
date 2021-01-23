    public class MyCommand 
               : ICommand
        {
            private readonly IDataErrorInfo _dataErrorInfo;
            private readonly Action _action;
    
            public MyCommand(IDataErrorInfo dataErrorInfo, Action action)
            {
                _dataErrorInfo = dataErrorInfo;
                _action = action;
            }
    
            #region ICommand Members
    
            public bool CanExecute(object parameter)
            {
                return string.IsNullOrEmpty(_dataErrorInfo.Error);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public void Execute(object parameter)
            {
                _action.Invoke();
            }
    
            #endregion
        }
