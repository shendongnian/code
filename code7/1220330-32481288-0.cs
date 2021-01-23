    public class AsyncDelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        bool _running;
        public event EventHandler CanExecuteChanged;
        public AsyncDelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return (_canExecute == null ? true : _canExecute(parameter)) && !_running;
        }
        public async void Execute(object parameter)
        {
            _running = true;
            Update();
            await Task.Run(() => _execute(parameter));
            _running = false;
            Update();
        }
        public void Update()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
