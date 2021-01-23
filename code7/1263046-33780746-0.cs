<!-- -->
   
    public partial class MainWindow : Window
    {
       public MainWindow()
       {
           InitializeComponent();
 
           var bitmapImage = new BitmapImage();
           bitmapImage.BeginInit();
           //set uri, or streamsource here
           bitmapImage.EndInit();
       
           this.Resources.Add("MyBitmapSource", bitmapImage);
       }
    }
