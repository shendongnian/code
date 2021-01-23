    public partial class MainWindow : Window
    {
        string Path = "C:/Users/Public/Pictures/Sample Pictures/Lighthouse.jpg";
        Preview prevwnd = new Preview();
        public MainWindow()
        {
            InitializeComponent();
            imgToPreview.Source = new BitmapImage(new Uri(Path));
            prevwnd = new Preview(Path);         
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
       private void imgToPreview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                prevwnd.Show();
            }
        }
    }
