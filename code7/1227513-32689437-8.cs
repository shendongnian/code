    public class MainViewModel : ViewModelBase
    {
        private int _progress;
        public MainViewModel()
        {
            // Open new window beside Main
            var otherView = new OtherWindow();
            otherView.Show();
            // Get downloader resource
            var downloader = Application.Current.Resources["MyDownloader"] as Downloader;
            // Update property when ever download progress changes (event)
            downloader.DownloadProgressChanged += (sender, args) => 
                Progress = args.ProgressPercentage;
            // Start downloading a 10Mb file
            downloader.Get("http://mirror.internode.on.net/pub/test/10meg.test");
        }
        public int Progress
        {
            get { return _progress; }
            private set { _progress = value; RaisePropertyChanged();}
        }
    }
