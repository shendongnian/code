    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public class MainWindowViewModel:INotifyPropertyChanged
        {
            private readonly ICommand _loadItemsCommand;
            private IEnumerable<string> _items;
            public event PropertyChangedEventHandler PropertyChanged;
            public MainWindowViewModel()
            {
                _loadItemsCommand = new DelegateCommand(LoadItemsExecute);
            }
        
            public IEnumerable<string> Items
            {
                get { return _items; }
                set { _items = value; OnPropertyChanged(nameof(Items)); }
            }
        
            public ICommand LoadItemsCommand
            {
                get { return _loadItemsCommand; }
            }
            private void LoadItemsExecute(object p)
            {
                Items = GenerateItems();
            }
            private IEnumerable<string> GenerateItems()
            {
                for(int i=0; i<10000; ++i)
                {
                    yield return "Item " + i;
                }
            }
            private void OnPropertyChanged(string propertyName)
            {
                var h = PropertyChanged;
                if (h!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public class DelegateCommand : ICommand
            {
                private readonly Predicate<object> _canExecute;
                private readonly Action<object> _execute;
                public event EventHandler CanExecuteChanged;
                public DelegateCommand(Action<object> execute) : this(execute, null) { }
                public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
                {
                    _execute = execute;
                    _canExecute = canExecute;
                }
                public bool CanExecute(object parameter)
                {
                    if (_canExecute == null)
                    {
                        return true;
                    }
                    return _canExecute(parameter);
                }
                public void Execute(object parameter)
                {
                    _execute(parameter);
                }
                public void RaiseCanExecuteChanged()
                {
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
    }
