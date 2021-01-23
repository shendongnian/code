    public class RelayCommand<T> : ICommand
    {
        public Action<T> _TargetExecuteMethod;
        public Func<T, bool> _TargetCanExecuteMethod;
        public RelayCommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }
        public bool CanExecute(object parameter)
        {
            if (_TargetExecuteMethod != null)
                return true;
            return false;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            T tParam = (T)parameter;
            if (_TargetExecuteMethod != null)
                _TargetExecuteMethod(tParam);
        }
    }
