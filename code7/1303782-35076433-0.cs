    public partial class MainWindow : Window
    {
        private double? _oldColumnJournalWindowWidth;
        // it is expanded when Width > 0
        public bool JournalExpanded
        {
            get { return ColumnJournalWindow.Width.Value > 0; }
        }
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            // Subscribe to event
            viewModel.JournalExpandedChanged += ViewModel_JournalExpandedChanged;
            DataContext = viewModel;
        }
        // When expanded set to either 100-0 or 50-50
        private void ViewModel_JournalExpandedChanged(object sender, EventArgs e)
        {
            ColumnMainWindow.Width = new GridLength(1, GridUnitType.Star);
            ColumnJournalWindow.Width = JournalExpanded ? new GridLength(0) : new GridLength(1, GridUnitType.Star);
        }
        // Handle expanding by click on splitter 
        private void GridSplitter_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_oldColumnJournalWindowWidth == null)
                return;
            // if splitter was moved do not change expand
            if (Math.Abs((double)_oldColumnJournalWindowWidth - ColumnJournalWindow.Width.Value) > 1)
                return;
            _oldColumnJournalWindowWidth = null;
            ViewModel_JournalExpandedChanged(sender, e);
        }
        // Only on left button
        private void GridSplitter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            _oldColumnJournalWindowWidth = ColumnJournalWindow.Width.Value;
        }
    }
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _journalExpandCommand;
        public ICommand JournalExpandCommand
        {
            get
            {
                return _journalExpandCommand ?? (_journalExpandCommand = new RelayCommand(OnJournalExpandedChanged));
            }
        }
        // Event to trigger JournalExpanded should change
        public event EventHandler JournalExpandedChanged;
        protected virtual void OnJournalExpandedChanged()
        {
            if (JournalExpandedChanged != null)
                JournalExpandedChanged(this, EventArgs.Empty);
        }
        // ...
    }
