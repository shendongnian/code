    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute( "code" )]
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true )]
    [System.Xml.Serialization.XmlRootAttribute( Namespace = "", IsNullable = false )]
    public partial class webParts
    {
        private webPart[ ] webPartField;        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute( "webPart", Namespace = "http://schemas.microsoft.com/WebPart/v3" )]
        public webPart[ ] webPart
        {
            get 
            {
                return this.webPartField;
            }
            set
            {
                this.webPartField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute( "code" )]
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true, Namespace = "http://schemas.microsoft.com/WebPart/v3" )]
    [System.Xml.Serialization.XmlRootAttribute( Namespace = "http://schemas.microsoft.com/WebPart/v3", IsNullable = false )]
    public partial class webPart
    {
        private string titleField;
        /// <remarks/>
        public string title
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
