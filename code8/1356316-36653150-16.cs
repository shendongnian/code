    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<LineViewModel> _lineViewModels;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<LineViewModel> LineViewModels
        {
            get { return _lineViewModels; }
            set
            {
                if (value == _lineViewModels) return;
                _lineViewModels = value;
                OnPropertyChange("LineViewModels");
            }
        }
        public MainWindowViewModel()
        {
            LineViewModels = new[]
            {
                new { AutoScale = false, Scale = 0.2 },
                new { AutoScale = true, Scale = 0.3 },
                new { AutoScale = false, Scale = 0.4 },
            }
                .Select(
                    x => new LineViewModel
                    {
                        IsAutoScale = x.AutoScale,
                        Scale = x.Scale
                    })
                .ToList();
        }
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
