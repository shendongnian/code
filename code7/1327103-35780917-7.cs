    public class SimpleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
    
            private Action<object> _execute;
            private Func<bool> _canExecute;
    
            public SimpleCommand(Action<object> execute) : this(execute, null) { }
    
            public SimpleCommand(Action<object> execute, Func<bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object param)
            {
                if (_canExecute != null)
                {
                    return _canExecute.Invoke();
                }
                else
                {
                    return true;
                }
            }
    
            public void Execute(object param)
            {
                _execute.Invoke(param);
            }
    
            protected void OnCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this,EventArgs.Empty);
            }
    
            #region Common Commands
            private static SimpleCommand _notImplementedCommand;
            public static ICommand NotImplementedCommand
            {
                get
                {
                    if (_notImplementedCommand == null)
                    {
                        _notImplementedCommand = new SimpleCommand(o => { throw new NotImplementedException(); });
                    }
                    return _notImplementedCommand;
                }
            }
            #endregion
        }
