    public class Program
    {
    	public static void Main()
    	{
    		List<Product> products = new List<Product>
		    {
		        new Product() {Id = 1, Name="name1", Color="Blue"},
		        new Product() {Id = 1, Name="name1", Color="Green"},
		        new Product() {Id = 1, Name="name1", Color="Green"},
		        new Product() {Id = 2, Name="name2", Color="Red"}
	        };
    								 
    		var results = from product in products
    			group product by product.Id into g // there is no need to group by a complex key if product.Id is unique per product
    			let colors = string.Join(",", g.Select(c=> c.Color).Distinct()) 
    			let p = g.First().Color = colors
    		    select g.First();
                    		
    		foreach(var result in results)
    		    Console.WriteLine(result);    		
    	}
    }
    
    public class Product
    {
        public int Id;
    	public string Name;
    	public string Color;
    	
    	public override string ToString()
    	{
    		return string.Format("Id:\"{0}\", Name:\"{1}\", Color:\"{2}\"", Id, Name, Color);
    	}
    }
