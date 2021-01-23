    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
        public static readonly DependencyProperty MouseCapturedProperty = DependencyProperty.Register(
            "MouseCaptured", typeof(bool), typeof(MainWindow));
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public bool MouseCaptured
        {
            get { return (bool)GetValue(MouseCapturedProperty); }
            set { SetValue(MouseCapturedProperty, value); }
        }
        private readonly IInputElement _captureElement;
        public MainWindow()
        {
            InitializeComponent();
            _captureElement = this;
            Mouse.AddGotMouseCaptureHandler((DependencyObject)_captureElement, stackPanel1_GotLostMouseCapture);
            Mouse.AddLostMouseCaptureHandler((DependencyObject)_captureElement, stackPanel1_GotLostMouseCapture);
            Mouse.Capture(_captureElement);
            MouseCaptured = Mouse.Captured != null;
        }
        private void stackPanel1_GotLostMouseCapture(object sender, MouseEventArgs e)
        {
            MouseCaptured = Mouse.Captured != null;
        }
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Value += e.Delta;
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            Mouse.Capture(_captureElement);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
            case Key.Escape:
                Mouse.Capture(null);
                break;
            case Key.Return:
                Mouse.Capture(_captureElement);
                break;
            }
        }
    }
