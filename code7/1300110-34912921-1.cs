    class Customer
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    	public List<Order> Orders { get; set; }    	
    }
    
    class Order 
    {
    	public int Id { get; set; }
    	public string Details { get; set; }
    }
