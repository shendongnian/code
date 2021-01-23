    public class MainViewModel : ViewModelBase
    {
        private int _progress;
        public MainViewModel()
        {
            var otherView = new OtherWindow();
            otherView.Show();
            var downloader = Application.Current.Resources["MyDownloader"] as Downloader;
            downloader.DownloadProgressChanged += (sender, args) => 
                Progress = args.ProgressPercentage;
            downloader.Get("http://mirror.internode.on.net/pub/test/10meg.test");
        }
        public int Progress
        {
            get { return _progress; }
            private set { _progress = value; RaisePropertyChanged();}
        }
    }
