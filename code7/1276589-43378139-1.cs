      public sealed partial class MainPage : Page
      {
        public MainPage()
        {
          this.InitializeComponent();
    
          Action<Order> navigateToOrderAction = order =>
          {
            this.Frame.Navigate(typeof(OrderDetailsPage), order);
          };
    
          OrdersVM orderVM = new OrdersVM(navigateToOrderAction);
          this.DataContext = orderVM;
        }
      }
