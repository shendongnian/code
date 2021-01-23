     public partial class UserControl1 : UserControl
    {  
        public static readonly DependencyProperty TextInUserControlProperty =
        DependencyProperty.Register("TextInUserControl",
            typeof(string),
            typeof(UserControl1));
        public string TextInUserControl
        {
            get { return (string)GetValue(TextInUserControlProperty); }
            set { SetValue(TextInUserControlProperty, value); }
        }
        public UserControl1()
        {
            InitializeComponent();           
            this.SetValue(UserControl1.TextInUserControlProperty, "My Text");
        }
    }
 
