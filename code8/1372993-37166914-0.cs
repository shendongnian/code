    public class RelayCommand : ICommand
    {
        private Action<object> action;
        public RelayCommand(Action<object> action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
     
        public void Execute(object parameter)
        {
            action(parameter);
        }
     
        public event EventHandler CanExecuteChanged;
    }
