    public partial class UserControl1 : UserControl
    {
        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value); }
        }
        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register("CustomText", typeof(string), typeof(UserControl1), new PropertyMetadata());
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
