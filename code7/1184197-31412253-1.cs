     public event EventHandler<OrderProgressEventArgs> OnOrderProgress;
     public class OrderProgressEventArgs : EventArgs
        {
            public int currentCount;
            public int totalCount;
            public string message;
            public OrderProgressEventArgs(int c, int t, string m)
            {
                currentCount = c;
                totalCount = t;
                message = m;
            }
        }
     protected virtual void OnOrderProgressChanged(OrderProgressEventArgs e)
        {
            EventHandler<OrderProgressEventArgs> handler = OnOrderProgress;
            if (handler != null)
            {
                handler(this, e);
            }
            }
     public abstract List<MasterSalesOrder> CreateOrders(List<BrandItem> BrandItems = null, List<BrandItemMasterCustomer> BrandItemMasterCustomers = null);
