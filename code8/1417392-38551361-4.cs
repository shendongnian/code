    internal class DelegateCommand<T> : ICommand
    {
        private Action<T> _clickAction;
        public DelegateCommand(Action<T> clickAction)
        {
            _clickAction = clickAction;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _clickAction((T)parameter);
        }
    }
