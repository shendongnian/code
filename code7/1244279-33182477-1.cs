    void Main()
    {
    	var items = new List<StockItem>();
    	items.Add(new UserQuery.StockItem { ID = "A", Value = 398.02m, Stock = 1100});
    	items.Add(new UserQuery.StockItem { ID = "B", Value = 1803.62m, Stock = 1100});
    	items.Add(new UserQuery.StockItem { ID = "A", Value = 480.07m, Stock = 1100});
    	items.Add(new UserQuery.StockItem { ID = "B", Value = 1794.89m, Stock = 1100});
    	items.Add(new UserQuery.StockItem { ID = "A", Value = 583.24m, Stock = 1100});
    	items.Add(new UserQuery.StockItem { ID = "B", Value = 1800.43m, Stock = 1100});
    	var query = from item in items
    				group item by new { item.Stock }
    				into stocks
    				select new { 
    					Stock = stocks.Key.Stock, 
    					A = stocks.Where(stock => stock.ID == "A").Min(stock => stock.Value), 
    					B = stocks.Where(stock => stock.ID == "B").Min(stock => stock.Value) 
    				};
    }
    
    public class StockItem
    {
    	public int Stock { get; set; }
    	public decimal Value { get; set; }
    	public string ID { get; set; }
    }
