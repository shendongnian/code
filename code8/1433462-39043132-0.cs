    public class MainWindowViewModel : PropertyChangedBase // from Calburn.Micro (see nuget)
    {
        private int _liquidHeight;
        public MainWindowViewModel()
        {
            LiquidPercentage = 25;
        }
        public int LiquidPercentage
        {
            get { return _liquidHeight; }
            set
            {
                if (value == _liquidHeight) return;
                _liquidHeight = value;
                NotifyOfPropertyChange(() => LiquidPercentage);
            }
        }
    }
