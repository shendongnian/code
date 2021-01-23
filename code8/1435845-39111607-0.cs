    public class MainPageViewModel : ViewModelBase
    {
        .............
        private Crew _crew = new Crew();
        public Crew Crew
        {
            get { return _crew; }
            set
            {
                if (_crew == value) return;
                _crew = value;
                RaisePropertyChanged(nameof(Crew));
            }
        }
        .......
    }
