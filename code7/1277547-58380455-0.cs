    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {
    
    	private rootEConnect eConnectField;
    
    	/// <remarks/>
    	public rootEConnect eConnect
    	{
    		get
    		{
    			return this.eConnectField;
    		}
    		set
    		{
    			this.eConnectField = value;
    		}
    	}
    }
    
    // Intermediate Xml nodes ...
      
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootEConnectCustomer
    {
    
    	private ushort cUSTNMBRField;
    
    	private string aDDRESS1Field;
    
    	private object aDDRESS2Field;
    
    	private object aDDRESS3Field;
    
    	private string aDRSCODEField;
    
        // rest of class ...
    }
