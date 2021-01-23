    public class KeyCommand : ICommand
    {
        Action<object> _execute;
        public event EventHandler CanExecuteChanged = delegate { };
        public KeyCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object param)
        {
            _execute(param);
        }
    }
