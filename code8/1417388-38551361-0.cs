    public class SchrankePresenter : INotifyPropertyChanged
    {
        private List<Schranke> _elements;
        public List<Schranke> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }
        public ICommand ClickCommand { get; set; }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public SchrankePresenter()
        {
            var elements = new List<Schranke>();
            for (var i = 1; i < 15; i++)
                elements.Add(new Schranke() { Name = $"Schranke NR:{i}" });
            Elements = elements;
            ClickCommand = new DelegateCommand(ClickAction);
        }
        public void ClickAction(Schranke item)
        {
            VibrationDevice.GetDefault().Vibrate(TimeSpan.FromMilliseconds(150));
        }
    }
    public class Schranke
    {
        public string Name { get; set; }
    }
