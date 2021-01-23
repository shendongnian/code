    public partial class MyUserControl : UserControl
    {
        static MyUserControl()
        {
            BorderBrushProperty.OverrideMetadata(
                typeof(MyUserControl),
                new FrameworkPropertyMetadata(Brushes.Black));
        }
        public MyUserControl()
        {
            InitializeComponent();
        }
    }
