    public partial class SearchedProductInternal : IProduct
    {
    	string IProduct.ID
    	{
    		get { return ObjectIdField.ToString(); }
    	}
    	
    	string IProduct.Name
    	{
		    get { return "Interface name"; }
    	}
    	
    	string IProduct.DescriptionShort
    	{
    		get { return shortDescriptionField; }
    	}
    	
    	string IProduct.DescriptionLong 
    	{
    		get { return longDescriptionField; }
    	}
        // Name property for the class, not the interface
  	    public string Name
	    {
		    get { return "Class name";	}
    	}
    }
