    public class RelayCommand : ICommand
        {
            Predicate<object> _canExecute;
            Action<object> _execute;
            bool _defaultBehaviourForCanExecute;
            public RelayCommand(Action<object> execute, bool defaultBehaviourForCanExecute = true, Predicate<object> canExecute = null)
            {
                _canExecute = canExecute;
                _execute = execute;
                _defaultBehaviourForCanExecute = defaultBehaviourForCanExecute;
            }
            public bool CanExecute(object parameter)
            {
                if (_canExecute != null)
                {
                    Logger.LogInformation("Evaluating can execute method for " + _canExecute.Method.DeclaringType + "->"+_canExecute.Method.Name);
                    return _canExecute.Invoke(parameter);
                }
                return _defaultBehaviourForCanExecute;
            }
            public event EventHandler CanExecuteChanged;
            public void RaiseCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, new EventArgs());
            }
            public void Execute(object parameter)
            {
                Logger.LogInformation("Executing command method for " + _execute.Method.DeclaringType + "->" + _execute.Method.Name);
                _execute.Invoke(parameter);
                RaiseCanExecuteChanged();
            }
        }  
