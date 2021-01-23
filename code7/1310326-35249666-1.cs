    public sealed partial class MasterPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }
        public Frame MyFrame
        {
            get { return (Frame)GetValue(MyFrameProperty); }
            set { SetValue(MyFrameProperty, value); }
        }
        public static readonly DependencyProperty MyFrameProperty =
            DependencyProperty.Register(nameof(MyFrame), typeof(Frame), 
                typeof(MasterPage), new PropertyMetadata(null));
    }
