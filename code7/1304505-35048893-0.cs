    using System;
    using System.Windows.Input;
    
    namespace WpfApplication
    {
        public class GlobalCommand<T> : ICommand
        {
            #region Fields
            private readonly Action<T> _execute = null;
            private readonly Predicate<T> _canExecute = null;
            private static GlobalCommand<T> _globalCommand; 
            private static readonly object locker = new object();
            #endregion
    
            #region Constructors
    
            public static GlobalCommand<T> GetInstance(Action<T> execute)
            {
                return GetInstance(execute, null);
            }
            public static GlobalCommand<T> GetInstance(Action<T> execute, Predicate<T> canExecute)
            {
                lock (locker)
                {
                    if (_globalCommand == null)
                    {
                        _globalCommand = new GlobalCommand<T>(execute, canExecute);
                    }
                }
                return _globalCommand;
            }
    
            private GlobalCommand(Action<T> execute, Predicate<T> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
    
                _execute = execute;
                _canExecute = canExecute;
            }
    
            #endregion
    
            #region ICommand Members
    
            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute((T)parameter);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested += value;
                }
                remove
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested -= value;
                }
            }
    
            public void Execute(object parameter)
            {
                _execute((T)parameter);
            }
    
            #endregion
        }
    }
