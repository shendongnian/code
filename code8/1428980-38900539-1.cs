    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class constituencyResults
    {
        private constituencyResultsConstituencyResult constituencyResultField;
        /// <remarks/>
        public constituencyResultsConstituencyResult constituencyResult
        {
            get
            {
                return this.constituencyResultField;
            }
            set
            {
                this.constituencyResultField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class constituencyResultsConstituencyResult
    {
        private byte consituencyIdField;
        private string constituencyNameField;
        private constituencyResultsConstituencyResultResult[] resultsField;
        private byte seqNoField;
        /// <remarks/>
        public byte consituencyId
        {
            get
            {
                return this.consituencyIdField;
            }
            set
            {
                this.consituencyIdField = value;
            }
        }
        /// <remarks/>
        public string constituencyName
        {
            get
            {
                return this.constituencyNameField;
            }
            set
            {
                this.constituencyNameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("result", IsNullable = false)]
        public constituencyResultsConstituencyResultResult[] results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte seqNo
        {
            get
            {
                return this.seqNoField;
            }
            set
            {
                this.seqNoField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class constituencyResultsConstituencyResultResult
    {
        private string partyCodeField;
        private ushort votesField;
        private decimal shareField;
        /// <remarks/>
        public string partyCode
        {
            get
            {
                return this.partyCodeField;
            }
            set
            {
                this.partyCodeField = value;
            }
        }
        /// <remarks/>
        public ushort votes
        {
            get
            {
                return this.votesField;
            }
            set
            {
                this.votesField = value;
            }
        }
        /// <remarks/>
        public decimal share
        {
            get
            {
                return this.shareField;
            }
            set
            {
                this.shareField = value;
            }
        }
    }
