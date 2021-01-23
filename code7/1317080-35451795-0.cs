    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class @class
    {
        private classHelpNavNode[] helpNavNodeField;
        private string titleField;
        private byte idField;
        private byte parentIDField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("helpNavNode")]
        public classHelpNavNode[] helpNavNode
        {
            get
            {
                return this.helpNavNodeField;
            }
            set
            {
                this.helpNavNodeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title
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
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ParentID
        {
            get
            {
                return this.parentIDField;
            }
            set
            {
                this.parentIDField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class classHelpNavNode
    {
        private classHelpNavNode[] helpNavNodeField;
        private string titleField;
        private byte idField;
        private byte parentIDField;
        private string narrativeField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("helpNavNode")]
        public classHelpNavNode[] helpNavNode
        {
            get
            {
                return this.helpNavNodeField;
            }
            set
            {
                this.helpNavNodeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title
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
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ParentID
        {
            get
            {
                return this.parentIDField;
            }
            set
            {
                this.parentIDField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Narrative
        {
            get
            {
                return this.narrativeField;
            }
            set
            {
                this.narrativeField = value;
            }
        }
    }
