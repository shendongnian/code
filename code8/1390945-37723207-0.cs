    class SimpleCommand : ICommand
    {
        public event EventHandler<object> Executed;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (Executed != null)
                Executed(this, parameter);
        }
        public event EventHandler CanExecuteChanged;
    }
