    public class BindableMapViewModel : PropertyChangedBase
    {
        private ObservableCollection<Pushpin> _Pushpins;
        public ObservableCollection<Pushpin> Pushpins
        {
            get { return _Pushpins; }
            set
            {
                _Pushpins = value;
                NotifyOfPropertyChange();
            }
        }
        public BindableMapViewModel()
        {
            Pushpins = new ObservableCollection<Pushpin>();
        }
    }
