    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public System.DateTime EditDate {
        get {
            return this.editDateField;
        }
        set {
            this.editDateField = value;
            this.RaisePropertyChanged("EditDate");
        }
    }
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool EditDateSpecified {
        get {
            return this.editDateFieldSpecified;
        }
        set {
            this.editDateFieldSpecified = value;
            this.RaisePropertyChanged("EditDateSpecified");
        }
    }
