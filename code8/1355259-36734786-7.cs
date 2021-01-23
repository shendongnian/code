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
            DependencyProperty.Register("MyClass", typeof(MyClass), typeof(MyUserControl), new UIPropertyMetadata(new PropertyChangedCallback(MyClassPropertyChanged)));
        private static void MyClassPropertyChanged(DependencyObject DO, DependencyPropertyChangedEventArgs e)
        {
            var MUC = DO as MyUserControl;
            if (e.NewValue != null)
            {
                var myClass = e.NewValue as MyClass;                
                MUC.MyCanvas.Children.Add(myClass.Button);
            }
        }
    }
