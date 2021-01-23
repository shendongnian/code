    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:gov:treasury:irs:common")]
    public partial class BulkExchangeFileType : object, System.ComponentModel.INotifyPropertyChanged
    {
        private IncludeType includeField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0, Namespace = "http://www.w3.org/2004/08/xop/include")]
        public IncludeType Include
        {
            get { return this.includeField; }
            set
            {
                this.includeField = value;
                this.RaisePropertyChanged("Include");
            }
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2004/08/xop/include")]
    public partial class IncludeType : object, System.ComponentModel.INotifyPropertyChanged
    {
        private System.Xml.XmlNode[] anyField;
        private string hrefField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public System.Xml.XmlNode[] Any
        {
            get { return this.anyField; }
            set
            {
                this.anyField = value;
                this.RaisePropertyChanged("Any");
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "string")]
        public string href
        {
            get { return this.hrefField; }
            set
            {
                this.hrefField = value;
                this.RaisePropertyChanged("href");
            }
        } 
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
