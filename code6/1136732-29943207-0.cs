    public partial class SearchedProductInternal : IProduct
    {
    	public string IProduct.ID
    	{
    		get { return ObjectIdField.ToString(); }
    	}
    	
    	public string IProduct.Name
    	{
    		//What do I do here?
    	}
    	
    	public string IProduct.DescriptionShort
    	{
    		get { return shortDescriptionField; }
    	}
    	
    	public string IProduct.DescriptionLong 
    	{
    		get { return longDescriptionField; }
    	}
    }
