    public class ActionCommand<T> : ICommand where T : class
    {
        private readonly Action<T> mAction;
        public ActionCommand(Action<T> action)
        {
            mAction = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            mAction(parameter as T);
        }
        public event EventHandler CanExecuteChanged;
    }
