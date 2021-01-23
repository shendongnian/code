    public static readonly DependencyProperty OrdersProperty = DependencyProperty.Register(nameof(Orders), typeof(List<Order>), typeof(Test), new PropertyMetadata(null));
    public List<Order>Orders
    {
        get { return (List<Order>) GetValue(OrdersProperty); }
        set { SetValue(OrdersProperty, value); }
    }
		
