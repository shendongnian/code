    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ConsoleApplication9", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:customers")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:customers", IsNullable=true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class AddressData : IAddressData {
        
        private string noField;
        
        private string roadField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public string no {
            get {
                return this.noField;
            }
            set {
                this.noField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string road {
            get {
                return this.roadField;
            }
            set {
                this.roadField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ConsoleApplication9", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:customers")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:customers", IsNullable=true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class CustomerData : ICustomerData {
        
        private string nameField;
        
        private AddressData addressField;
        
        private System.DateTime order_dateField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AddressData address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public System.DateTime order_date {
            get {
                return this.order_dateField;
            }
            set {
                this.order_dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ConsoleApplication9", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:customers")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:customers", IsNullable=true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class CatalogData : ICatalogData {
        
        private CustomerData[] customerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("customer", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CustomerData[] customer {
            get {
                return this.customerField;
            }
            set {
                this.customerField = value;
            }
        }
    }
    
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public interface IAddressData {
        
        
        
        /// <remarks/>
        string no {
            get;
            set;
        }
        
        /// <remarks/>
        string road {
            get;
            set;
        }
    }
    
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public interface ICustomerData {
        
        
        
        
        
        /// <remarks/>
        string name {
            get;
            set;
        }
        
        /// <remarks/>
        AddressData address {
            get;
            set;
        }
        
        /// <remarks/>
        System.DateTime order_date {
            get;
            set;
        }
        
        /// <remarks/>
        string id {
            get;
            set;
        }
    }
    
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public interface ICatalogData {
        
        
        /// <remarks/>
        CustomerData[] customer {
            get;
            set;
        }
    }
