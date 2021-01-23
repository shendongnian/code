    public class DownloadViewModel:INotifyPropertyChanged
    {
        private IProgress<double> _progress;
        private double _progressValue;
        public IProgress<double> Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }
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
            Progress = new Progress<double>(ProgressValueChanged);
        }
        private void ProgressValueChanged(double d)
        {
            ProgressValue = d;
        }
        public async void StartDownload(string address, string location)
        {
            await new MyDlClass().DownloadProtocol(Progress, address, location);
        }
        //-----------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
