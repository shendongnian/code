    using System.Xml.Serialization;
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class OrderDetail {
    
        private string messageTypeCodeField;
    
        private string orderDetailIdField;
    
        private OrderDetailClientInfo[] clientInfoField;
    
        private OrderDetailOrderTaxesOrderTax[][] orderTaxesField;
    
        private OrderDetailOrderTransactionsOrderTransaction[][] orderTransactionsField;
    
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string MessageTypeCode {
        get {
            return this.messageTypeCodeField;
        }
        set {
            this.messageTypeCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string OrderDetailId {
        get {
            return this.orderDetailIdField;
        }
        set {
            this.orderDetailIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ClientInfo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public OrderDetailClientInfo[] ClientInfo {
        get {
            return this.clientInfoField;
        }
        set {
            this.clientInfoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("OrderTax", typeof(OrderDetailOrderTaxesOrderTax), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public OrderDetailOrderTaxesOrderTax[][] OrderTaxes {
        get {
            return this.orderTaxesField;
        }
        set {
            this.orderTaxesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("OrderTransaction", typeof(OrderDetailOrderTransactionsOrderTransaction), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public OrderDetailOrderTransactionsOrderTransaction[][] OrderTransactions {
        get {
            return this.orderTransactionsField;
        }
        set {
            this.orderTransactionsField = value;
        }
    }
}
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OrderDetailClientInfo {
    
    private string clientNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ClientName {
        get {
            return this.clientNameField;
        }
        set {
            this.clientNameField = value;
        }
    }
