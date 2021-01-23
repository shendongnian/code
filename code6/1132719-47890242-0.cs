    ///The rest of the code given as context as I'm working on a T4 template to create Model classes from Datalayer classes, so the iteration is required in my case
    void Main()
    {
    	CVH p = new CVH();
    	Type t = p.GetType();
    	
    	foreach (PropertyInfo prop in t.GetProperties()) //Iterating through properties
    	{
    		foreach (var facet in prop.GetCustomAttributes()) //Yank out attributes
    		{
    		//The bit you need
    			if ((Type)facet.TypeId == typeof(StringLengthAttribute)) //What type of attribute is this? 
    			{
    				StringLengthAttribute _len = (StringLengthAttribute)facet; //Cast it to grab Maximum/MinimumLengths etc.
    				Console.WriteLine($"My maximum field length is { _len.MaximumLength}");
    				//End of the bit you need
    				Console.WriteLine(_len.MinimumLength);				
    			}
    		}
    	}
    }
    ///Test class with some attributes
    public class CVH
    {
    	[StringLength(50)]
    	[DataType(DataType.PhoneNumber)]
    	public string phone_1 { get; set; }
    	[Required(ErrorMessage = "id is required")]
    	public int id { get; set; }
    	[Required(ErrorMessage = "id is required")]
    	public int contact_id { get; set; }
    }
