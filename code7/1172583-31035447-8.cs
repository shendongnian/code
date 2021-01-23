    public enum StatesTypes
    {
        Disabled = 0,
        Enabled = 1
    }
    public class Category
    {
    	public int Id { get; set; }
    
    	public StatesTypes State { get; set; }
    
    	public String Name { get; set; }
    }
