    public class AddRecordEventArgs : EventArgs
    {
    	public AddRecordEventArgs(string qty, string desc, string price) {
    		Quantity = qty;
    		Description = desc;
    		Price = price;
    	}
    	
    	public int Quantity { get; private set; }
    	public string Description { get; private set; }
    	public decimal Price { get; private set; }
    }
