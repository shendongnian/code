    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Orders.Add(new Order { OrderNo = "Order001" });
            Orders.Add(new Order { OrderNo = "Order002" });
            Orders.Add(new Order { OrderNo = "Order003" });
        }
        private readonly ObservableCollection<Order> _orders = new ObservableCollection<Order>();
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
        }
    }
    public class Order
    {
        public Order()
        {
            States.Add(new State { Text = "Is Paid", Value = false });
            States.Add(new State { Text = "Is Delivered", Value = false });
        }
        public string OrderNo { get; set; }
        private readonly ObservableCollection<State> _states = new ObservableCollection<State>();
        public ObservableCollection<State> States
        {
            get { return _states; }
        }
    }
    public class State
    {
        public string Text { get; set; }
        public bool Value { get; set; }
    }
