    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Func<bool> _canExecute;
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    } 
    public MyViewModel()
    {
        ButtonCommand = new RelayCommand(ButtonClick);
    }
    private void ButtonClick(object obj)
    {
        //obj is the object you send as parameter.
    }
