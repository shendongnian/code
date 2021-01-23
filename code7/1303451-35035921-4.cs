        public static class VisualTreeHelperExtensions
    {
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            while (true)
            {
                //get parent item
                DependencyObject parentObject = VisualTreeHelper.GetParent(child);
                //we've reached the end of the tree
                if (parentObject == null) return null;
                //check if the parent matches the type we're looking for
                T parent = parentObject as T;
                if (parent != null)
                    return parent;
                child = parentObject;
            }
        }
    }
    public class BaseObservableObject : INotifyPropertyChanged
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
    public class RelayCommand<T> : ICommand
        where T:class 
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
        public RelayCommand(Action<T> execute):this(obj => true, execute)
        {
        }
        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter as T);
        }
        public void Execute(object parameter)
        {
            _execute(parameter as T);
        }
        public event EventHandler CanExecuteChanged;
    }
