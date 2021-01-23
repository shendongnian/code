    public class MainWindowViewModel : PropertyChangedBase // from Calburn.Micro (see nuget)
    {
        private int _liquidPerc;
        public MainWindowViewModel()
        {
            LiquidPercentage = 25;
        }
        public int LiquidPercentage
        {
            get { return _liquidPerc; }
            set
            {
                if (value == _liquidPerc) return;
                _liquidPerc= value;
                NotifyOfPropertyChange(() => LiquidPercentage);
            }
        }
    }
