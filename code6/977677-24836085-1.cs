     /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
     [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Information
    {
    private object[] itemsField;
    private ItemsChoiceType[] itemsElementNameField;
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Location", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("claim_details", typeof(InformationClaim_details))]
    [System.Xml.Serialization.XmlElementAttribute("claim_form_id", typeof(ushort))]
    [System.Xml.Serialization.XmlElementAttribute("customer_support_phone_number", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("customer_support_url", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("employee_id", typeof(ushort))]
    [System.Xml.Serialization.XmlElementAttribute("employer_id", typeof(byte))]
    [System.Xml.Serialization.XmlElementAttribute("employer_name", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("employer_url", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("first_name", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("label", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("last_name", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("received_date", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("set_flag", typeof(byte))]
    [System.Xml.Serialization.XmlElementAttribute("tax", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
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
      /// <remarks/>
      [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
      [System.Xml.Serialization.XmlIgnoreAttribute()]
      public ItemsChoiceType[] ItemsElementName
      {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
       }
      }
     /// <remarks/>
     [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InformationClaim_details
    {
    private ushort claim_form_idField;
    private byte amount_claimedField;
    private string expense_nameField;
    private System.DateTime service_dateField;
    private string claim_statusField;
    private object claim_status_reasonField;
    /// <remarks/>
    public ushort claim_form_id
    {
        get
        {
            return this.claim_form_idField;
        }
        set
        {
            this.claim_form_idField = value;
        }
    }
    /// <remarks/>
    public byte amount_claimed
    {
        get
        {
            return this.amount_claimedField;
        }
        set
        {
            this.amount_claimedField = value;
        }
    }
    /// <remarks/>
    public string expense_name
    {
        get
        {
            return this.expense_nameField;
        }
        set
        {
            this.expense_nameField = value;
        }
    }
     /// <remarks/>
      [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
     public System.DateTime service_date
      {
        get
        {
            return this.service_dateField;
        }
        set
        {
            this.service_dateField = value;
        }
    }
    /// <remarks/>
    public string claim_status
    {
        get
        {
            return this.claim_statusField;
        }
        set
        {
            this.claim_statusField = value;
        }
      }
  
      /// <remarks/>
       public object claim_status_reason
      {
        get
        {
            return this.claim_status_reasonField;
        }
        set
        {
            this.claim_status_reasonField = value;
           }
        }
    }
 
