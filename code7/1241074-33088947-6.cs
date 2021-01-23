    class DelegateDependencyCommand<T> : DependencyObject, ICommand
    {
        public static readonly DependencyProperty IsExecutableProperty = DependencyProperty.Register(
            "IsExecutable", typeof(bool), typeof(DelegateCommand<T>), new PropertyMetadata(true, OnIsExecutableChanged));
        public bool IsExecutable
        {
            get { return (bool)GetValue(IsExecutableProperty); }
            set { SetValue(IsExecutableProperty, value); }
        }
        private static void OnIsExecutableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DelegateDependencyCommand<T> command = (DelegateDependencyCommand<T>)d;
            EventHandler handler = command.CanExecuteChanged;
            if (handler != null)
            {
                handler(command, EventArgs.Empty);
            }
        }
        private readonly Action<T> _executeHandler;
        public DelegateDependencyCommand(Action<T> executeHandler)
        {
            _executeHandler = executeHandler;
        }
        public bool CanExecute(object parameter)
        {
            return IsExecutable;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _executeHandler((T)parameter);
        }
    }
