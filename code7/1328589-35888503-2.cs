     [System.Xml.Serialization.XmlIncludeAttribute(typeof(Book))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookstore.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://bookstore.com/", IsNullable=true)]
    public partial class Publication {
        
        private PersonReference[] authorReferenceField;
        
        private string titleField;
        
        [System.Xml.Serialization.XmlElementAttribute("AuthorReference")]
        public PersonReference[] AuthorReference {
            get {
                return this.authorReferenceField;
            }
            set {
                this.authorReferenceField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookstore.com/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://bookstore.com/", IsNullable=true)]
    public partial class PersonReference {
        
        private string refField;
        
        /// <uwagi/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookstore.com/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://bookstore.com/", IsNullable=true)]
    public partial class Person {
        
        private string nameField;
        
        private string surnameField;
        
        private string idField;
        
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        public string Surname {
            get {
                return this.surnameField;
            }
            set {
                this.surnameField = value;
            }
        }
        
        /// <uwagi/>
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
    
