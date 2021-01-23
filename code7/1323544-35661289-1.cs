        [System.Xml.Serialization.XmlElementAttribute("PntList2D", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("PntList3D", typeof(string))]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
