    public sealed partial class MainPage : Page
    {
        private ObservableCollection<BitmapImage> ImgList = new ObservableCollection<BitmapImage>();
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("screenshotCapture");
            var files = await folder.GetFilesAsync();
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(stream);
                    ImgList.Add(bitmapImage);
                }
            }
        }
    }
