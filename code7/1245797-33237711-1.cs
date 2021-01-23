    public partial class MainWindow : Window
    {
       public MainWindow()
       {
          InitializeComponent(); 
          // Create list
          MyImageDimensionCol col = new MyImageDimensionCol();
          col.ImageDimensions = new ObservableCollection<ImageDimension>();
          col.ImageDimensions.Add(new ImageDimension() { Height = 5, Width = 10 });
          col.ImageDimensions.Add(new ImageDimension() { Height = 15, Width = 20 });
          col.ImageDimensions.Add(new ImageDimension() { Height = 5, Width = 5 });
          DataContext = col;
       }
    }
    public class MyImageDimensionCol
    {
       public ObservableCollection<ImageDimension> ImageDimensions { get; set; }
    }
    public class ImageDimension
    {
       public int Height { get; set; }
       public int Width { get; set; }
    }
