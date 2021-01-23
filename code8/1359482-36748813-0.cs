    void Main()
    {
    	var cart = new List<Cart>();
    	
    	cart.Add(new Cart { ID = 10, isInventory = true, Pricing = 4 });
    	cart.Add(new Cart { ID = 10, isInventory = true, Pricing = 20});
    	cart.Add(new Cart { ID = 10, isInventory = false, Pricing = 5});
     	cart.Add(new Cart { ID = 10, isInventory = false, Pricing = 23});
    	cart.Add(new Cart { ID = 74, isInventory = false, Pricing = 7});
    
    	var grouped = from c in cart
    				  orderby c.isInventory, c.ID
    				  select c;
    				  
        grouped.Dump();
    }
    
    public class Cart
    {
    	public int ID { get; set; }
    	public bool isInventory { get; set; }
    	public int Pricing { get; set; }
    	
    }
