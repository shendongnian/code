    public class TestFunctional {
    	public TestFunctional(){
    		DataItems = new List<DataItem>();
    	}
    	
    	public List<DataItem> DataItems { get; set; }
    	
    	private void AddOneItem(){
    		var newItem = new DataItem {
    			LOB = "a",
    			Quantity = 1,
    			Name = "A",
    			Packing = true,
    			Code = "a1"
    		};
    		
    		DataItems.Add(newItem);
    		
    		RefreshGrid();
    	}
    
    	private void AddMultipleItems(){
    		var newItem1 = new DataItem {
    			LOB = "a",
    			Quantity = 1,
    			Name = "A",
    			Packing = true,
    			Code = "a1"
    		};
    		
    		var newItem2 = new DataItem {
    			LOB = "b",
    			Quantity = 2,
    			Name = "B",
    			Packing = false,
    			Code = "b2"
    		};
    		
    		DataItems.Add(newItem1);
    		DataItems.Add(newItem2);
    		
    		/*or use DataItems.AddRange( ... ) */
    		
    		RefreshGrid();
    	}
    	
    	private void RefreshGrid()
    	{
    		gridviewDtaInserted.Rows.Clear();
    		gridviewDtaInserted.Refresh();
    		
    		gridviewDtaInserted.DataSource = DataItems;
    	}
    }
    
    public class DataItem{
    	public string LOB { get; set; }
    	public double Quantity { get; set; }
    	public string Name { get; set; }
    	public bool Packing { get; set; }
    	public decimal Price { get; set; }
    	public string Code { get; set; }	
    }
