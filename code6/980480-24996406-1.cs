    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OrderDetailOrderTaxesOrderTax {
    
    private string taxIdField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TaxId {
        get {
            return this.taxIdField;
        }
        set {
            this.taxIdField = value;
        }
    }
}
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OrderDetailOrderTransactionsOrderTransaction {
    
    private string loanAmountField;
    
    private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor[][][] titleField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string LoanAmount {
        get {
            return this.loanAmountField;
        }
        set {
            this.loanAmountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("TitleVendors", typeof(OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor[]), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("TitleVendor", typeof(OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false, NestingLevel=1)]
    public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor[][][] Title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
