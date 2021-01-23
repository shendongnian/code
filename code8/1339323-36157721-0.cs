    void Main()
    {
    	List<Order> orders; /* some orders */
    
    	IEnumerable<OrderLine> filteredOrderLines =
    		orders
    		.SelectMany(order => order.OrderLineList)
    		.Where(orderLineList => orderLineList.sku != "ABOLIVE");
    }
    
    class Order
    {
    	public List<OrderLine> OrderLineList { get; set; }
    }
    
    class OrderLine
    {
    	public String sku { get; set; }
    }
