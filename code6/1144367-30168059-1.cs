    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            CommandA = new DelegateCommand(() => IsOpen = true);
            CommandB = new DelegateCommand(() => IsOpen = true);
        }
        public DelegateCommand CommandA { get; set; }
        public DelegateCommand CommandB { get; set; }
        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                OnPropertyChanged(() => IsOpen);
            }
        }
    }
