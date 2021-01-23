    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://blah.co.uk")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://blah.co.uk", IsNullable = false)]
    public partial class PlaceOrderResponse
    {
        private PlaceOrderResponsePlaceOrderResult placeOrderResultField;
        /// <remarks/>
        public PlaceOrderResponsePlaceOrderResult PlaceOrderResult
        {
            get
            {
                return this.placeOrderResultField;
            }
            set
            {
                this.placeOrderResultField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://blah.co.uk")]
    public partial class PlaceOrderResponsePlaceOrderResult
    {
        private ErrorDetails errorDetailsField;
        private object idField;
        private object informationalMessagesField;
        private byte statusField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://blah.co.uk/WebserviceMessage")]
        public ErrorDetails ErrorDetails
        {
            get
            {
                return this.errorDetailsField;
            }
            set
            {
                this.errorDetailsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://blah.co.uk/WebserviceMessage", IsNullable = true)]
        public object ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://blah.co.uk/WebserviceMessage")]
        public object InformationalMessages
        {
            get
            {
                return this.informationalMessagesField;
            }
            set
            {
                this.informationalMessagesField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://blah.co.uk/WebserviceMessage")]
        public byte Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://blah.co.uk/WebserviceMessage")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://blah.co.uk/WebserviceMessage", IsNullable = false)]
    public partial class ErrorDetails
    {
        private ErrorDetail errorDetailField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://blah.co.uk/Error")]
        public ErrorDetail ErrorDetail
        {
            get
            {
                return this.errorDetailField;
            }
            set
            {
                this.errorDetailField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://blah.co.uk/Error")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://blah.co.uk/Error", IsNullable = false)]
    public partial class ErrorDetail
    {
        private string codeField;
        private string messageField;
        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
