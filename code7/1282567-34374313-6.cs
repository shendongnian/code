    public class Customer
    {
    	public string Name { get; set; }
    	public List<Item> Order { get; set; }
    }
    public class Item
    {
    	public Product Product { get; set; }
    	public int Quantity { get; set; }
    }
    public class Product
    {
    	public int Id { get; set; }
    }
