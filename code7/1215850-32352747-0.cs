        [XmlElement("data", Namespace = "http://tmp.com/zzz/pivot/event")]
        public object data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
