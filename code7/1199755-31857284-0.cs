    public class ReactiveCommand : ICommand, IObservable<object>
    {
        private bool _canExecute = true;
        private readonly Subject<object> _execute = new Subject<object>();
        public ReactiveCommand(IObservable<bool> canExecute = null)
        {
            if (canExecute != null)
            {
                canExecute.Subscribe(x => this._canExecute = x);
            }
        }
        public bool CanExecute(object parameter)
        {
            return this._canExecute;
        }
        public void Execute(object parameter)
        {
            this._execute.OnNext(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public IDisposable Subscribe(IObserver<object> observer)
        {
            return this._execute.Subscribe(observer);
        }
    }
