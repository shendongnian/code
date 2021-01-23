    public partial class MainWindow : Window
    {
        public BitmapImage bitmap;
        public MainWindow()
        {
            InitializeComponent();
    
            bitmap = new BitmapImage();
    
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("C:\\Temp\\the_ugly_baby.jpg", UriKind.Absolute);
            bitmap.EndInit();
            imgPlaceholder.Source = null;
    
        }
    
        private void LoadImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            imgPlaceholder.Source = bitmap;
        }
    
        private void LoadImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = imgPlaceholder.Source == null ? true : false;
        }
    
        private void UnloadImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = imgPlaceholder.Source != null ? true : false;
        }
    
        private void UnloadImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            imgPlaceholder.Source = null;
        }
    }
