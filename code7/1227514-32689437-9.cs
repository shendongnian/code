    public partial class OtherWindow : Window
    {
        public OtherWindow()
        {
            InitializeComponent();
            // Get downloader resource
            var downloader = Application.Current.Resources["MyDownloader"] as Downloader;
            // Update label when ever download progress changes (event)
            downloader.DownloadProgressChanged += (sender, args) => 
                ProgressLabel.Content = string.Format("{0}%", args.ProgressPercentage);
        }
    }
