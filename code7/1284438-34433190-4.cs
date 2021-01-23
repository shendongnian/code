    public sealed partial class MainPage : Page
    {
        public ObservableCollection<BitmapImage> ImgList = new ObservableCollection<BitmapImage>();
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            showImage();
        }
        public async void showImage()
        {
            var query = GetAll();
            foreach (var stuff in query)
            {
                string FileName = stuff.RecipeImage;
                var file = await Windows.Storage.KnownFolders.PicturesLibrary.GetFileAsync(FileName);
                var stream = await file.OpenReadAsync();
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream);
                ImgList.Add(bitmapImage);
            }
        }
    }
