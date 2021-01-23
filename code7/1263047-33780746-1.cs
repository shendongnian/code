<!-- -->
    public partial class MainWindow : Window
    {
       public ObservableCollection<BitmapImage> MyBitmapSources { get; private set; }
       public MainWindow()
       {
           MyBitmapSources = new ObservableCollection<BitmapImage>();
           InitializeComponent();
 
           var bitmapImage = new BitmapImage();
           bitmapImage.BeginInit();
           //set uri, or streamsource here
           bitmapImage.EndInit();
       
           MyBitmapSources.Add(bitmapImage);
       }
    }
