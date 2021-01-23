     /// <summary>
    /// implements the INotifyPropertyChanged (.net 4.5)
    /// </summary>
    public class DisposableBaseObservableObject : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> raiser)
        {
            var propName = ((MemberExpression)raiser.Body).Member.Name;
            OnPropertyChanged(propName);
        }
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
                return true;
            }
            return false;
        }
        #region Disposable
        private bool _isDisposed;
        ~DisposableBaseObservableObject()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            GC.SuppressFinalize(this);
            _isDisposed = true;
            DisposeOverride();
        }
        protected virtual void DisposeOverride()
        {
        }
        #endregion
    }
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        public RelayCommand(Action execute)
            : this(() => true, execute)
        {
        }
        public RelayCommand(Func<bool> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public bool CanExecute(object parameter = null)
        {
            return _canExecute();
        }
        public void Execute(object parameter = null)
        {
            _execute();
        }
        public event EventHandler CanExecuteChanged;
    }
