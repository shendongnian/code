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
        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            prevwnd.Show();
        }
        private void imgToPreview_MouseLeave(object sender, MouseEventArgs e)
        {
            prevwnd.Hide();
        }
    }
