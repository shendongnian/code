    public sealed class DownloadViewModel : INotifyPropertyChanged
    {
        private readonly IProgress<double> _progress;
        private double _progressValue;
        
        public double ProgressValue
        {
            get
            {
                return _progressValue;
            }
            set
            {
                _progressValue = value;
                OnPropertyChanged();
            }
        }
        public DownloadViewModel()
        {
            _progress = new Progress<double>(ProgressValueChanged);
        }
        private void ProgressValueChanged(double d)
        {
            ProgressValue = d;
        }
        public async void StartDownload(string address, string location)
        {
            await new MyDlClass().DownloadProtocol(_progress, address, location);
        }
        //-----------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
