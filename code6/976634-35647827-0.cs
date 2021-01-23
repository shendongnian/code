    public partial class MainWindow : Window
        {
            Point locationOfYourControl;
            public MainWindow()
            {
                    InitializeComponent();
                    this.ContentRendered += MainWindow_ContentRendered;
            }
            private void MainWindow_ContentRendered(object sender, EventArgs e)
            {
                locationOfYourControl = YourControl.PointToScreen(new Point(0, 0));
            }
        }
