    public class SomeData
    {
    	public int Key { get; set; }
    	public decimal Value { get; set; }
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		List<SomeData> orders = new List<SomeData>();
    
    		orders.Add(new SomeData { Key = 10, Value = 14 });
    		orders.Add(new SomeData { Key = 25, Value = 22 });
    		orders.Add(new SomeData { Key = 567, Value = 3 });
    		orders.Add(new SomeData { Key = 57, Value = 300 });
    		orders.Add(new SomeData { Key = 17, Value = 200 });
    		orders.Add(new SomeData { Key = 343, Value = 42 });
    
    		List<int> ids = new List<int> { 1, 25, 700, 567, 343, 350, 10 };
    
    		//get orders only from ids with order
    		List<SomeData> existedOrders = (from order in orders
    										join id in ids
    											 on new { onlyId = order.Key }
    											equals new { onlyId = id }
    										orderby ids.IndexOf(id)
    										select order).ToList();
    
    		//add others
    		existedOrders.AddRange(orders.Except(existedOrders).ToList());
    
    	}
    }
