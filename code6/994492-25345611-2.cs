    public class Flex
    {
    	public Flex()
    	{
    		itemsField = new List<object>();
    	}
    
    	public Flex(object item) : this()
    	{
    		itemsField.Add(item);
    	}
    
    	private List<object> itemsField;
    
    	[System.Xml.Serialization.XmlElementAttribute("attr", typeof(AttrRddType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrMany", typeof(AttrRddManyType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrQual", typeof(AttrQualRddType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrQualMany", typeof(AttrQualRddManyType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrQualOpt", typeof(AttrQualOptRddType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrQualOptMany", typeof(AttrQualOptRddManyType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrGroup", typeof(AttrGroupType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	[System.Xml.Serialization.XmlElementAttribute("attrGroupMany", typeof(AttrGroupManyType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	public List<object> Items
    	{
    		get
    		{
    			return this.itemsField;
    		}
    		set
    		{
    			this.itemsField = value;
    		}
    	}
    }
        
