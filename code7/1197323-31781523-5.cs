    public class KeyCommand : ICommand
    {
        Action _execute;
        public event EventHandler CanExecuteChanged = delegate { };
        public KeyCommand(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object param)
        {
            _execute();
        }
    }
