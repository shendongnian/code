    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class param
    {
        private paramProfessor professorField;
        private paramProfessor1 professorField1;
        private paramCourse[] courseField;
        /// <remarks/>
        public paramProfessor professor
        {
            get
            {
                return this.professorField;
            }
            set
            {
                this.professorField = value;
            }
        }
        /// <remarks/>
        public paramProfessor1 Professor
        {
            get
            {
                return this.professorField1;
            }
            set
            {
                this.professorField1 = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("course")]
        public paramCourse[] course
        {
            get
            {
                return this.courseField;
            }
            set
            {
                this.courseField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class paramProfessor
    {
        private byte idField;
        private string nameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
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
    public partial class paramProfessor1
    {
        private byte idField;
        private string nameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
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
    public partial class paramCourse
    {
        private byte idField;
        private string nameField;
        private bool biolabField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool biolab
        {
            get
            {
                return this.biolabField;
            }
            set
            {
                this.biolabField = value;
            }
        }
    }
