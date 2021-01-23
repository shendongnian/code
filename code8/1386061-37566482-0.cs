    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {
    	private rootRating[] ratingField;
    
    	[XmlElementAttribute("rating")]
    	public rootRating[] rating
    	{
    		get
    		{
    			return this.ratingField;
    		}
    		set
    		{
    			this.ratingField = value;
    		}
    	}
    }
    
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class rootRating
    {
    
    	private string cityField;
    
    	private string codeField;
    
    	private string valueField;
    
    	[XmlAttributeAttribute()]
    	public string city
    	{
    		get
    		{
    			return this.cityField;
    		}
    		set
    		{
    			this.cityField = value;
    		}
    	}
    
    	[XmlAttributeAttribute()]
    	public string code
    	{
    		get
    		{
    			return this.codeField;
    		}
    		set
    		{
    			this.codeField = value;
    		}
    	}
    
    	[XmlTextAttribute()]
    	public string Value
    	{
    		get
    		{
    			return this.valueField;
    		}
    		set
    		{
    			this.valueField = value;
    		}
    	}
    }
