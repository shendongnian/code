    public partial class SearchedProductInternal : IProduct
    {
    	string IProduct.ID
    	{
    		get { return ObjectIdField.ToString(); }
    	}
    	
    	string IProduct.Name
    	{
    		//What do I do here?
    	}
    	
    	string IProduct.DescriptionShort
    	{
    		get { return shortDescriptionField; }
    	}
    	
    	string IProduct.DescriptionLong 
    	{
    		get { return longDescriptionField; }
    	}
    }
