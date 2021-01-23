    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
