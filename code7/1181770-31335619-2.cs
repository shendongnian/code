     public class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canexecute;
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> Execute, Predicate<object> Canexecute)
        {
            if(Execute == null)
                throw new ArgumentNullException("execute");
            execute = Execute;
            canexecute = Canexecute;
        }
        public bool CanExecute(object parameter)
        {
            if(canexecute == null)
                return true;
            else
                return canexecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
