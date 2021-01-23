    abstract class Pagination<T>
    {
        // Other properties
		public List<T> items { get; set; }
    }
    class OrderHeader : Pagination<OrderLine>
    {
        // Other properties
    }
    class OrderLine : Pagination<OrderLineDetails>
    {
        // Other properties
    }
	
	class OrderLineDetails
    {
        // Other properties
    }
