    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Signal> _source;
        public IEnumerable<Signal> MySource
        {
            get { return _source; }
        }
        private RawVal _rawValSelected;
        public RawVal RawValSelected
        {
            get { return _rawValSelected; }
            set
            {
                _rawValSelected = value;
                
                RaisePropertyChanged("RawValSelected");
            }
        }
        public void RaisePropertyChanged(string propName)
        {
            var pc = PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs(propName));
            }
        }
        public ViewModel()
        {
            _source = new ObservableCollection<Signal>
            {
                new Signal{
                    Name = "Test",
                    Value = 1,
                    rawValue = new ObservableCollection<RawVal>
                    {
                        new RawVal{name="Search Key Trigger",value=4},
                        new RawVal{name="Tailgate Key Trigger",value=3},
                        new RawVal{name="Un-Lock Key Trigger",value=2},
                        new RawVal{name="Lock Key Trigger",value=1},
                        new RawVal{name="No Remote RQ Trigger",value=0}
                    }
                }
            };
        }
    }
