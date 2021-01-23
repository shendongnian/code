    public partial class your_control : UserControl
    {
        public delegate void delete_event_handler(your_control sender);
        public event delete_event_handler delete;
        public your_control()
        {
            this.InitializeComponent();
        }
        private void on_bu_click(object sender, RoutedEventArgs e)
        {
            // the event is null if there is no listeners bind to it
            if (this.delete != null)
                this.delete(this);
        }
    }
