    public partial class MainWindow : Window
        {
            PictureViewer viewer { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = viewer ?? (viewer = new PictureViewer());
            }
    
            private void button_Previous_Click(object sender, RoutedEventArgs e)
            {
                viewer.Previous();
            }
    
            private void button_Next_Click(object sender, RoutedEventArgs e)
            {
                viewer.Next();
            }
