    public class ViewModelBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand ExpandingCommand { get; set; }
        private void ExecuteExpandingCommand(object obj)
        {
            Console.WriteLine(@"Expanded");
        }
        private bool CanExecuteExpandingCommand(object obj)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            ExpandingCommand = new RelayCommand(ExecuteExpandingCommand, CanExecuteExpandingCommand);
            Cat = new ObservableCollection<ScenarioCategory>(new ScenarioCategory[] 
            {
                new ScenarioCategory { Name = "C1" }, new ScenarioCategory { Name = "C2" }, new ScenarioCategory { Name = "C3" }
            });
        }
        public ObservableCollection<ScenarioCategory> Cat { get; set; }
    }
    public class ScenarioCategory : ViewModelBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        bool _isExtended;
        public bool IsExtended
        {
            get { return _isExtended; }
            set
            {
                _isExtended = value;
                Console.WriteLine(@"IsExtended set");
                OnPropertyChanged();
            }
        }
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                Console.WriteLine(@"IsSelected set");
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Scenario> ScenarioList { get; set; }
        public ScenarioCategory()
        {
            ScenarioList = new ObservableCollection<Scenario>(new Scenario[] { new Scenario { Name = "1" }, new Scenario { Name = "2" }, new Scenario { Name = "3" } });
        }
    }
    public class Scenario : ViewModelBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        bool _isExtended;
        public bool IsExtended
        {
            get { return _isExtended; }
            set
            {
                _isExtended = value;
                OnPropertyChanged();
            }
        }
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
    public static class Behaviours
    {
        public static readonly DependencyProperty ExpandingBehaviourProperty =
            DependencyProperty.RegisterAttached("ExpandingBehaviour", typeof(ICommand), typeof(Behaviours),
                new PropertyMetadata(OnExpandingBehaviourChanged));
        public static void SetExpandingBehaviour(DependencyObject o, ICommand value)
        {
            o.SetValue(ExpandingBehaviourProperty, value);
        }
        public static ICommand GetExpandingBehaviour(DependencyObject o)
        {
            return (ICommand)o.GetValue(ExpandingBehaviourProperty);
        }
        private static void OnExpandingBehaviourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeViewItem tvi = d as TreeViewItem;
            if (tvi != null)
            {
                ICommand ic = e.NewValue as ICommand;
                if (ic != null)
                {
                    tvi.Expanded += (s, a) =>
                    {
                        if (ic.CanExecute(a))
                        {
                            ic.Execute(a);
                        }
                        a.Handled = true;
                    };
                }
            }
        }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
