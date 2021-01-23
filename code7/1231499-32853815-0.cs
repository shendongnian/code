    [System.Xml.Serialization.XmlElementAttribute("businessKeys", typeof(BusinessKeys))]
            [System.Xml.Serialization.XmlElementAttribute("id", typeof(string))]
            public object Item {
                get {
                    return this.itemField;
                }
                set {
                    this.itemField = value;
                }
            }
