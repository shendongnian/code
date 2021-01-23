    public partial class CloseButton : UserControl
    {
        public event EventHandler Click;
        public CloseButton()
        {
            InitializeComponent();
            innerButton.Click += ButtonClick;
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var eventHandler = this.Click;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
