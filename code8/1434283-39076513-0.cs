    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherOperation _action;
        private int _width = 2000;
        private int _height = 1000;
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.Hooks.OperationCompleted += HooksOnOperationCompleted;
        }
        private void HooksOnOperationCompleted(object sender, DispatcherHookEventArgs dispatcherHookEventArgs)
        {
            if(dispatcherHookEventArgs.Operation != _action) return;
            _action.Task.ContinueWith((t) =>
            {
                Rectangle rect = new Rectangle(0, 0, _width, _height);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                bmp.Save("help" + DateTime.Now.Ticks + ".jpg", ImageFormat.Jpeg);
            });
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _action = Dispatcher.BeginInvoke((Action) (() =>
            {
                Top = 10000;
                Visibility = Visibility.Collapsed;
            }));
        }
    }
