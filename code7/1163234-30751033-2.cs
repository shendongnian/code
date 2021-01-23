    public partial class MainWindow : Window
    {
    public Model ImageModel { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        ImageModel = new Model();
        ImageModel.ImagePath = new Uri(@"/ImageSource;component/Images/Image1.jpg", UriKind.RelativeOrAbsolute);
        this.DataContext = ImageModel;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ImageModel.ImagePath = new Uri(@"/ImageSource;component/Images/Image2.jpg", UriKind.RelativeOrAbsolute);
    }
