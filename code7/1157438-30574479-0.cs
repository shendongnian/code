    public class Product
    {
    	public Field Field { get; set; }
    }
    
    public class Field
    {
    	public bool SubField { get; set; }
    }
    private bool GetSubField(Product product)
    {
    	Console.WriteLine("GetSubField");
    	return product.Field.SubField;
    }
