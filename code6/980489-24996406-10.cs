    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class     OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor {
    
    private string vendorInstructionsField;
    
    private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService[][] vendorServicesField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string VendorInstructions {
        get {
            return this.vendorInstructionsField;
        }
        set {
            this.vendorInstructionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("TitleVendorService", typeof(OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService[][] VendorServices {
        get {
            return this.vendorServicesField;
        }
        set {
            this.vendorServicesField = value;
        }
    }
}
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService {
    
    private string titleVendorServiceIdField;
    
    private string serviceCodeField;
    
    private string customVendorInstructionsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TitleVendorServiceId {
        get {
            return this.titleVendorServiceIdField;
        }
        set {
            this.titleVendorServiceIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ServiceCode {
        get {
            return this.serviceCodeField;
        }
        set {
            this.serviceCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CustomVendorInstructions {
        get {
            return this.customVendorInstructionsField;
        }
        set {
            this.customVendorInstructionsField = value;
        }
    }
