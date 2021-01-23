     using System;
        using System.Windows.Input;
    
        namespace TestPopWpfWindow
        {
          
            public class RelayCommand : ICommand
            {
        
                private Predicate<object> _canExecute;
        
                private Action<object> _execute;  
         
        
                public RelayCommand(Predicate<object> canExecute, Action<object> execute)
                {
                    _canExecute = canExecute;
                    _execute = execute;
                }
        
                public bool CanExecute(object parameter)
                {
                    return _canExecute(parameter); 
                }
        
                public event EventHandler CanExecuteChanged;
        
                public void Execute(object parameter)
                {
                    _execute(parameter); 
                }
        
            }
        }
