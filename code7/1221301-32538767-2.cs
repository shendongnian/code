    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Bitmap image = VisualToBitmapConverter.GetBitmap(border,
                    (int)border.ActualWidth, (int)border.ActualHeight);
    
                image.Save(@"C:\YourPath\test.png");
            }
        }
    }
