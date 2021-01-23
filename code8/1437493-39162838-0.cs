    public class AsyncRelayCommand : RelayCommand
    {
        private readonly Func<Task> _asyncExecute;
        public AsyncRelayCommand(Func<Task> asyncExecute)
            : base(() => asyncExecute())
        {
            _asyncExecute = asyncExecute;
        }
        public AsyncRelayCommand(Func<Task> asyncExecute, Action execute)
            : base(execute)
        {
            _asyncExecute = asyncExecute;
        }
        public Task ExecuteAsync()
        {
            return _asyncExecute();
        }
        public override void Execute(object parameter)
        {
            _asyncExecute();
        }
    }
