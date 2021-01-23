    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class element
    {
    
    	private elementComplexType complexTypeField;
    
    	private string nameField;
    
    	/// <remarks/>
    	public elementComplexType complexType
    	{
    		get
    		{
    			return this.complexTypeField;
    		}
    		set
    		{
    			this.complexTypeField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string name
    	{
    		get
    		{
    			return this.nameField;
    		}
    		set
    		{
    			this.nameField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class elementComplexType
    {
    
    	private elementComplexTypeElement[] sequenceField;
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlArrayItemAttribute("element", IsNullable = false)]
    	public elementComplexTypeElement[] sequence
    	{
    		get
    		{
    			return this.sequenceField;
    		}
    		set
    		{
    			this.sequenceField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class elementComplexTypeElement
    {
    
    	private byte minOccursField;
    
    	private string maxOccursField;
    
    	private string nameField;
    
    	private string typeField;
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public byte minOccurs
    	{
    		get
    		{
    			return this.minOccursField;
    		}
    		set
    		{
    			this.minOccursField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string maxOccurs
    	{
    		get
    		{
    			return this.maxOccursField;
    		}
    		set
    		{
    			this.maxOccursField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string name
    	{
    		get
    		{
    			return this.nameField;
    		}
    		set
    		{
    			this.nameField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string type
    	{
    		get
    		{
    			return this.typeField;
    		}
    		set
    		{
    			this.typeField = value;
    		}
    	}
    }
