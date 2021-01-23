    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty SomeProperty = SomeControl.SomeProperty.AddOwner(
            typeof (UserControl1), new FrameworkPropertyMetadata() {Inherits = true});
        public UserControl1()
        {
            InitializeComponent();
        }
        public int Some
        {
            get { return (int) GetValue(SomeProperty); }
            set { SetValue(SomeProperty, value); }
        }
    }
