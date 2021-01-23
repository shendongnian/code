    void Main()
    {
    	var testList = Test.CreateList();
    	
    	var tmp = (from t in testList
    			   group t by new { t.Name } into g
    			   select new
    			   {
    				   Name = g.Key.Name,
    				   xColor = g.Sum(a =>
    				   {
    					   if (a.Product == "x" && a.Color == true)
    						   return a.Quantity;
    					   return 0;
    				   }),
    				    xBW = g.Sum(a =>
    				   {
    					   if (a.Product == "x" && a.Color == false)
    						   return a.Quantity;
    					   return 0;
    				   })
    			   });
    
    	tmp.Dump();
    }
    
    public class Test
    {
    	public string Name { get; set; }
    
    	public string Product { get; set;}
    	
    	public bool Color { get; set;}
    	
    	public int? Quantity { get; set;}
    
    	public static List<Test> CreateList()
    	{
    		return new List<Test>()
    		{
    		  new Test {Name="A",Color = true,Product="x",Quantity=5},
    		  new Test {Name="A",Color = true,Product="x",Quantity=5},
    		  new Test {Name="A",Color = true,Product="x",Quantity=5},
    		  new Test {Name="B",Color = true,Product="x",Quantity=5},
    		  new Test {Name="B",Color = true,Product="x",Quantity=5},
    		  new Test {Name="B",Color = true,Product="x",Quantity=5}		  
    		};
    	}
    }
