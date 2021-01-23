    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }        
    }
    public static class ImageLoader
    {
        public static List<BitmapImage> LoadImages()
        {
            List<BitmapImage> robotImages = new List<BitmapImage>();
            DirectoryInfo robotImageDir = new DirectoryInfo(@"..\folder");
            foreach (FileInfo robotImageFile in robotImageDir.GetFiles("*.jpeg"))
            {
                Uri uri = new Uri(robotImageFile.FullName);
                robotImages.Add(new BitmapImage(uri));
            }
            return robotImages;
        }
    }
