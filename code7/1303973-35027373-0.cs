        [XmlIgnore]
        public MyClassType MyClass { get; set; }
        [XmlElement("MyClass")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public MyClassType GetMyClassForXml
        {
            get
            {
                return MyClass;
            }
            set
            {
                // DO NOTHING
            }
        }
