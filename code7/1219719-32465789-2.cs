    public partial class MainWindow : Window
    {
        string Path = "C:/Users/Public/Pictures/Sample Pictures/Lighthouse.jpg";
        Uri imgSource;
        Preview prevwnd = new Preview();
        public MainWindow()
        {
            InitializeComponent();
            imgSource = new Uri(Path, UriKind.Relative);
            imgToPreview.Source = new BitmapImage(new Uri(Path));
            prevwnd = new Preview(Path);         
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            prevwnd.Show();
        }
        private void imgToPreview_MouseLeave(object sender, MouseEventArgs e)
        {
            prevwnd.Hide();
        }
    }
