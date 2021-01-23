    public partial class MyUserControl : UserControl
    {
        public string customObject
        {
            get { return (string)GetValue(customObjectProperty); }
            set { SetValue(customObjectProperty, value); }
        }
        public static readonly DependencyProperty customObjectProperty =
            DependencyProperty.Register("customObject", typeof(string), typeof(MyUserControl), null);
        public string objName
        {
            get { return (string)GetValue(objNameProperty); }
            set { SetValue(objNameProperty, value); }
        }
        public static readonly DependencyProperty objNameProperty =
            DependencyProperty.Register("objName", typeof(string), typeof(MyUserControl), null);
        public MyUserControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = CustomObjectFactory.GetCustomObject(customObject);
            objName = obj.GetTypeName();
            DataContext = this;
        }
