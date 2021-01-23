    public class DataCache
    {
        private static DataCache singletonInstance;
        // You can have freedom to choose the event-driven model here
        // Using traditional Event, EventAggregator, ReactiveX, etc
        public EventHandler OnMessageChanged;
        private DataCache()
        {
            
        }
        public static DataCache Instance
        {
            get { return singletonInstance ?? (singletonInstance = new DataCache()); }
        }
        public string OnScreenMessage { get; set; }
        public void AddStringToMessage(string c)
        {
            if (string.IsNullOrWhiteSpace(c)) return;
            OnScreenMessage += c;
            RaiseOnMessageChanged();
        }
        public void ClearMessage()
        {
            OnScreenMessage = string.Empty;
            RaiseOnMessageChanged();
        }
        private void RaiseOnMessageChanged()
        {
            if (OnMessageChanged != null)
                OnMessageChanged(null, null);            
        }
    }
    public class MainViewModel : ViewModelBase
    {
        private readonly MessageViewModel messageVM;
        private readonly KeyboardViewModel keyboardVM;
        private readonly ButtonsViewModel buttonsVM;
        private readonly DataCache dataCache;
        public MainViewModel()
        {
            messageVM = new MessageViewModel();
            keyboardVM = new KeyboardViewModel();
            buttonsVM = new ButtonsViewModel();
        }
        public ViewModelBase MessageViewModel { get { return messageVM; } }
        public ViewModelBase KeyboardViewModel { get { return keyboardVM;  } }
        public ViewModelBase ButtonsViewModel { get { return buttonsVM; } }
    }
    public class MessageViewModel : ViewModelBase
    {
        private readonly DataCache dataCache = DataCache.Instance;
        public MessageViewModel()
        {
            dataCache.OnMessageChanged += RaiseMessageChanged;
        }
        private void RaiseMessageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("Message");
        }
        public string Message
        {
            get { return dataCache.OnScreenMessage; }
            set { dataCache.OnScreenMessage = value; }
        }
    }
    public class KeyboardViewModel : ViewModelBase
    {
        private readonly DataCache dataCache = DataCache.Instance;
        private ICommand onClickButtonCommand;
        public ICommand OnClickButton
        {
            get
            {
                return onClickButtonCommand ?? (onClickButtonCommand = new RelayCommand(p => dataCache.AddStringToMessage((string)p))); 
            }
        }
    }
    public class ButtonsViewModel : ViewModelBase
    {
        private readonly DataCache dataCache = DataCache.Instance;
        private ICommand onGoBackCommand;
        public ICommand OnGoBackButton
        {
            get
            {
                return onGoBackCommand ?? (onGoBackCommand = new RelayCommand(p => dataCache.ClearMessage()));
            }
        }
    }
    public class RelayCommand : ICommand
    {
        #region Fields
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        #endregion Fields
        #region Constructors
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion Constructors
        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion ICommand Members
    }
    <Window x:Class="StudentScoreWpfProj.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:StudentScoreWpfProj"        
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance Type=local:MainViewModel,IsDesignTimeCreatable=True}"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <local:MessgaeView DataContext="{Binding MessageViewModel}" />
        <local:KeyboardView Grid.Row="1" DataContext="{Binding KeyboardViewModel}" />
        <local:ButtonsView Grid.Row="2" DataContext="{Binding ButtonsViewModel}" />
    </Grid>
