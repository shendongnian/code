    public class AsyncCompositeCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private readonly IEnumerable<IAsyncCommand> commands;
        private readonly Action<object> executedCallback;
        public AsyncCompositeCommand(IEnumerable<IAsyncCommand> commands, Action<object> executedCallback)
        {
            this.commands = commands;
            this.executedCallback = executedCallback;
        }
        public bool CanExecute(object parameter)
        {
            return commands.Any(x => x.CanExecute(parameter));
        }     
        public async Task ExecuteAsync(object parameter)
        {
            var pendingTasks = commands.Select(c=> c.ExecuteAsync(parameter))
                                        .ToList();
            await Task.WhenAll(pendingTasks);
            executedCallback(parameter);//Notify
        }
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
    }
