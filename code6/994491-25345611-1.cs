    
    public class AttrGroupManyType
    {
        (...)
    
    	[System.Xml.Serialization.XmlElementAttribute("row", typeof(Flex), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    	public List<Flex> row
    	{
    		get
    		{
    			return this._row;
    		}
    		set
    		{
    			this._row = value;
    		}
    	}
    }
    
