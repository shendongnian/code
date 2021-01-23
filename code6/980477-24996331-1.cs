    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class OrderDetail
    {
    
        private uint messageTypeCodeField;
    
        private uint orderDetailIdField;
    
        private OrderDetailClientInfo clientInfoField;
    
        private OrderDetailOrderTaxes orderTaxesField;
    
        private OrderDetailOrderTransactions orderTransactionsField;
    
        /// <remarks/>
        public uint MessageTypeCode
        {
            get
            {
                return this.messageTypeCodeField;
            }
            set
            {
                this.messageTypeCodeField = value;
            }
        }
    
        /// <remarks/>
        public uint OrderDetailId
        {
            get
            {
                return this.orderDetailIdField;
            }
            set
            {
                this.orderDetailIdField = value;
            }
        }
    
        /// <remarks/>
        public OrderDetailClientInfo ClientInfo
        {
            get
            {
                return this.clientInfoField;
            }
            set
            {
                this.clientInfoField = value;
            }
        }
    
        /// <remarks/>
        public OrderDetailOrderTaxes OrderTaxes
        {
            get
            {
                return this.orderTaxesField;
            }
            set
            {
                this.orderTaxesField = value;
            }
        }
    
        /// <remarks/>
        public OrderDetailOrderTransactions OrderTransactions
        {
            get
            {
                return this.orderTransactionsField;
            }
            set
            {
                this.orderTransactionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailClientInfo
    {
    
        private string clientNameField;
    
        /// <remarks/>
        public string ClientName
        {
            get
            {
                return this.clientNameField;
            }
            set
            {
                this.clientNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTaxes
    {
    
        private OrderDetailOrderTaxesOrderTax orderTaxField;
    
        /// <remarks/>
        public OrderDetailOrderTaxesOrderTax OrderTax
        {
            get
            {
                return this.orderTaxField;
            }
            set
            {
                this.orderTaxField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTaxesOrderTax
    {
    
        private uint taxIdField;
    
        /// <remarks/>
        public uint TaxId
        {
            get
            {
                return this.taxIdField;
            }
            set
            {
                this.taxIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactions
    {
    
        private OrderDetailOrderTransactionsOrderTransaction orderTransactionField;
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransaction OrderTransaction
        {
            get
            {
                return this.orderTransactionField;
            }
            set
            {
                this.orderTransactionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransaction
    {
    
        private object loanAmountField;
    
        private OrderDetailOrderTransactionsOrderTransactionTitle titleField;
    
        /// <remarks/>
        public object LoanAmount
        {
            get
            {
                return this.loanAmountField;
            }
            set
            {
                this.loanAmountField = value;
            }
        }
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransactionTitle Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitle
    {
    
        private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendors titleVendorsField;
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendors TitleVendors
        {
            get
            {
                return this.titleVendorsField;
            }
            set
            {
                this.titleVendorsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitleTitleVendors
    {
    
        private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor titleVendorField;
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor TitleVendor
        {
            get
            {
                return this.titleVendorField;
            }
            set
            {
                this.titleVendorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendor
    {
    
        private string vendorInstructionsField;
    
        private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServices vendorServicesField;
    
        /// <remarks/>
        public string VendorInstructions
        {
            get
            {
                return this.vendorInstructionsField;
            }
            set
            {
                this.vendorInstructionsField = value;
            }
        }
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServices VendorServices
        {
            get
            {
                return this.vendorServicesField;
            }
            set
            {
                this.vendorServicesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServices
    {
    
        private OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService titleVendorServiceField;
    
        /// <remarks/>
        public OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService TitleVendorService
        {
            get
            {
                return this.titleVendorServiceField;
            }
            set
            {
                this.titleVendorServiceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetailOrderTransactionsOrderTransactionTitleTitleVendorsTitleVendorVendorServicesTitleVendorService
    {
    
        private uint titleVendorServiceIdField;
    
        private string serviceCodeField;
    
        private string customVendorInstructionsField;
    
        /// <remarks/>
        public uint TitleVendorServiceId
        {
            get
            {
                return this.titleVendorServiceIdField;
            }
            set
            {
                this.titleVendorServiceIdField = value;
            }
        }
    
        /// <remarks/>
        public string ServiceCode
        {
            get
            {
                return this.serviceCodeField;
            }
            set
            {
                this.serviceCodeField = value;
            }
        }
    
        /// <remarks/>
        public string CustomVendorInstructions
        {
            get
            {
                return this.customVendorInstructionsField;
            }
            set
            {
                this.customVendorInstructionsField = value;
            }
        }
    }
