    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class shapes
    {
    
        private shapesFunctionalBlock[] functionalBlocksField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FunctionalBlock", IsNullable = false)]
        public shapesFunctionalBlock[] FunctionalBlocks
        {
            get
            {
                return this.functionalBlocksField;
            }
            set
            {
                this.functionalBlocksField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class shapesFunctionalBlock
    {
    
        private shapesFunctionalBlockProp[] propsField;
    
        private shapesFunctionalBlockPos posField;
    
        private shapesFunctionalBlockConnects connectsField;
    
        private string uidField;
    
        private string nameField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("prop", IsNullable = false)]
        public shapesFunctionalBlockProp[] props
        {
            get
            {
                return this.propsField;
            }
            set
            {
                this.propsField = value;
            }
        }
    
        /// <remarks/>
        public shapesFunctionalBlockPos pos
        {
            get
            {
                return this.posField;
            }
            set
            {
                this.posField = value;
            }
        }
    
        /// <remarks/>
        public shapesFunctionalBlockConnects connects
        {
            get
            {
                return this.connectsField;
            }
            set
            {
                this.connectsField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string uid
        {
            get
            {
                return this.uidField;
            }
            set
            {
                this.uidField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class shapesFunctionalBlockProp
    {
    
        private string nameField;
    
        private string valueField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class shapesFunctionalBlockPos
    {
    
        private decimal leftField;
    
        private decimal topField;
    
        private decimal rightField;
    
        private decimal bottomField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal left
        {
            get
            {
                return this.leftField;
            }
            set
            {
                this.leftField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal top
        {
            get
            {
                return this.topField;
            }
            set
            {
                this.topField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal right
        {
            get
            {
                return this.rightField;
            }
            set
            {
                this.rightField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal bottom
        {
            get
            {
                return this.bottomField;
            }
            set
            {
                this.bottomField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class shapesFunctionalBlockConnects
    {
    
        private object inField;
    
        private object outField;
    
        private object undirectedField;
    
        /// <remarks/>
        public object In
        {
            get
            {
                return this.inField;
            }
            set
            {
                this.inField = value;
            }
        }
    
        /// <remarks/>
        public object Out
        {
            get
            {
                return this.outField;
            }
            set
            {
                this.outField = value;
            }
        }
    
        /// <remarks/>
        public object Undirected
        {
            get
            {
                return this.undirectedField;
            }
            set
            {
                this.undirectedField = value;
            }
        }
    }
