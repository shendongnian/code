    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public MyClass MyClass
        {
            get { return (MyClass)GetValue(MyClassProperty); }
            set { SetValue(MyClassProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyClass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyClassProperty =
            DependencyProperty.Register("MyClass", typeof(MyClass), typeof(MyUserControl), new UIPropertyMetadata(null));
    }
