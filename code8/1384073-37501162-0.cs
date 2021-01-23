    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private bool hybridSeed;
        public bool HybridSeed
        {
            get { return hybridSeed; }
            set
            {
                hybridSeed = value;
                OnPropertyChanged(nameof(HybridSeed));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
