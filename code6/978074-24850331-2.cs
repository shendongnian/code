    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class currents
    {
        private currentsCurrent[] currentField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("current")]
        public currentsCurrent[] current
        {
            get
            {
                return this.currentField;
            }
            set
            {
                this.currentField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentsCurrent
    {
        private byte currentCodeField;
        private string currentNameField;
        private string currentAddressField;
        private uint currentTelField;
        private uint faxField;
        private string currentProvinceField;
        private string currentCountyField;
        private string taxOfficeField;
        private ushort taxNoField;
        private string currentTypeField;
        private ushort postalCodeField;
        private string countryCodeField;
        private byte additionalCurrentCodeField;
        private byte idField;
        /// <remarks/>
        public byte currentCode
        {
            get
            {
                return this.currentCodeField;
            }
            set
            {
                this.currentCodeField = value;
            }
        }
        /// <remarks/>
        public string currentName
        {
            get
            {
                return this.currentNameField;
            }
            set
            {
                this.currentNameField = value;
            }
        }
        /// <remarks/>
        public string currentAddress
        {
            get
            {
                return this.currentAddressField;
            }
            set
            {
                this.currentAddressField = value;
            }
        }
        /// <remarks/>
        public uint currentTel
        {
            get
            {
                return this.currentTelField;
            }
            set
            {
                this.currentTelField = value;
            }
        }
        /// <remarks/>
        public uint fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }
        /// <remarks/>
        public string currentProvince
        {
            get
            {
                return this.currentProvinceField;
            }
            set
            {
                this.currentProvinceField = value;
            }
        }
        /// <remarks/>
        public string currentCounty
        {
            get
            {
                return this.currentCountyField;
            }
            set
            {
                this.currentCountyField = value;
            }
        }
        /// <remarks/>
        public string taxOffice
        {
            get
            {
                return this.taxOfficeField;
            }
            set
            {
                this.taxOfficeField = value;
            }
        }
        /// <remarks/>
        public ushort taxNo
        {
            get
            {
                return this.taxNoField;
            }
            set
            {
                this.taxNoField = value;
            }
        }
        /// <remarks/>
        public string currentType
        {
            get
            {
                return this.currentTypeField;
            }
            set
            {
                this.currentTypeField = value;
            }
        }
        /// <remarks/>
        public ushort postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }
        /// <remarks/>
        public string countryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
        /// <remarks/>
        public byte additionalCurrentCode
        {
            get
            {
                return this.additionalCurrentCodeField;
            }
            set
            {
                this.additionalCurrentCodeField = value;
            }
        }
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
    }
