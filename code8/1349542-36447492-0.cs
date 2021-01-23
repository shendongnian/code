    [ContentProperty("InnerContent")]
    public partial class ModernButton : UserControl
    {
        public ModernButton()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty InnerContentProperty =
            DependencyProperty.Register("InnerContent", typeof(object), typeof(ModernButton));
        public object InnerContent
        {
            get { return (object)GetValue(InnerContentProperty); }
            set { SetValue(InnerContentProperty, value); }
        }
    }
