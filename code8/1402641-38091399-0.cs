    public partial class UC1 : UserControl
    {
        public UC1()
        {
            InitializeComponent();
        }
    
        public static readonly DependencyProperty GetUserControlProperty =
        DependencyProperty.Register("GetUserControl2", typeof(UserControl),
        typeof(UC1), null);
    
        public UserControl GetUserControl2
        {
            get
            {
                return (UserControl)GetValue(GetUserControlProperty);
            }
            set
            {
                SetValue(GetUserControlProperty, value);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             GetUserControl2.Visibility = Visibility.Collapsed;
        }
    }
