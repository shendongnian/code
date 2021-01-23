    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty StrokeXProperty =
            DependencyProperty.Register("StrokeX", typeof(Enums.Strokes), typeof(MyControl), new PropertyMetadata(Enums.Strokes.Off));
        public Enums.Strokes StrokeX
        {
            get { return (Enums.Strokes)GetValue(StrokeXProperty); }
            set
            {
                SetValue(StrokeXProperty, value);
            }
        }
        private void OnButton_Click(object sender, RoutedEventArgs e)
        {
            this.StrokeX = Enums.Strokes.On;
        }
        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            this.StrokeX = Enums.Strokes.Off;
        }
    }
