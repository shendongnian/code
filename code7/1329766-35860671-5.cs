    public partial class SuperTextControl : UserControl
    {
        public event EventHandler SplitEvent;
        public event EventHandler DeleteEvent;
        public SuperTextControl()
        {
            InitializeComponent();
        }
        private void SplitHandler(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender; // fyi
            if (SplitEvent != null)
            {
                SplitEvent(this, new EventArgs());
            }
        }
        private void DeleteHandler(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender; // fyi
            if (DeleteEvent != null)
            {
                DeleteEvent(this, new EventArgs());
            }
        }
    }
