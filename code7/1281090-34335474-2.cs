    public sealed partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty FigurinePathProperty = DependencyProperty.Register(
            "FigurinePath", typeof (Uri), typeof (MyUserControl), new PropertyMetadata(default(Uri)));
        public Uri FigurinePath
        {
            get { return (Uri) GetValue(FigurinePathProperty); }
            set { SetValue(FigurinePathProperty, value); }
        }
        public MyUserControl()
        {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }
    }
