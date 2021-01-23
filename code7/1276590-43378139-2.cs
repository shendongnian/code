      public sealed partial class OrderDetailsPage : Page
      {
        public OrderDetailsPage()
        {
          this.InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          Order selectedOrder = e.Content as Order;
          if (selectedOrder != null)
          { //Do something with the selected order
            this.DataContext = selectedOrder;
          }
          base.OnNavigatedTo(e);
        }
      }
