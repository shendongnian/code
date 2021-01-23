    public partial class DualButton : UserControl
    {
        public DualButton()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent ClickEvent =
    EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
    typeof(RoutedEventHandler), typeof(DualButton));
        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Left");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Right");
        }
    }
