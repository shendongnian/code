        public class BaseCommand : ICommand
            {
                protected Func<object, bool> _canExecute;
                protected Action<object> _execute;
        
                public BaseCommand()
                {
                }
        
                public BaseCommand(Func<object, bool> canExcecute, Action<object> execute)
                {
                    _canExecute = canExcecute;
                    _execute = execute;
                }
                public bool CanExecute(object parameter)
                {
                    return _canExecute(parameter);
               
    
     }
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
            public event EventHandler CanExecuteChanged;
        }
    
     public bool CanExecute(object parameter)
     {
         return _canExecute(parameter);
     }
    
    public void Execute(object parameter)
     {
          _execute(parameter);
     }
