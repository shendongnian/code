    public class Item
    {
	    public string Name { get; set; }
    	public string CompanyCode { get; set; }
	    public DateTime ShipToDate { get; set; }
    	public List<string> Address { get; set; }
	    public Item()
	    {
            //Uncomment Address initialization and the test fails..
		    //Address = new List<string>(); 
	    }
    }
