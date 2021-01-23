    public partial class OtherWindow : Window
    {
        public OtherWindow()
        {
            InitializeComponent();
            var downloader = Application.Current.Resources["MyDownloader"] as Downloader;
            downloader.DownloadProgressChanged += (sender, args) => 
                ProgressLabel.Content = string.Format("{0}%", args.ProgressPercentage);
        }
    }
