        /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EditTicket editTicket=new EditTicket();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Loaded -= OnLoaded;
            Unloaded -= OnUnloaded;
            editTicket.EditFinished -= RefreshEnteredTickets;
            
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            editTicket.EditFinished += RefreshEnteredTickets;
        }
        private void RefreshEnteredTickets(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            editTicket.Show();
        }
    }
        /// <summary>
    /// Interaction logic for EditTicket.xaml
    /// </summary>
    public partial class EditTicket : Window
    {
        //public event EventHandler EditFinished;
        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent EditFinishedEvent;
        static EditTicket()
        {
            EditFinishedEvent = EventManager.RegisterRoutedEvent(
                "EditFinished", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (EditTicket));
        }
        public EditTicket()
        {
            InitializeComponent();
        }
        
        // Provide CLR accessors for the event
        public event RoutedEventHandler EditFinished
        {
            add { AddHandler(EditFinishedEvent, value); }
            remove { RemoveHandler(EditFinishedEvent, value); }
        }
        // This method raises the EditFinished event
        void RaiseEditFinishedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(EditFinishedEvent, this);
            RaiseEvent(newEventArgs);
            MessageBox.Show("Raised Routed");
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEditFinishedEvent();
        }
    }
