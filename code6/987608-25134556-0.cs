    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Model
    {
        private ModelPart partField;
        public ModelPart Part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ModelPart
    {
        private ModelPartSpecs specsField;
        private byte idField;
        public ModelPartSpecs Specs
        {
            get
            {
                return this.specsField;
            }
            set
            {
                this.specsField = value;
            }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Id
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
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ModelPartSpecs
    {
        private ModelPartSpecsSpec specField;
        public ModelPartSpecsSpec Spec
        {
            get
            {
                return this.specField;
            }
            set
            {
                this.specField = value;
            }
        }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ModelPartSpecsSpec
    {
        private byte idField;
        private string nameField;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Id
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
