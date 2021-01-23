    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SellingCode
    {
        private System.DateTime lastUpdatedField;
        private ulong[] sellingCodeIDField;
        private uint productIDField;
        /// <remarks/>
        public System.DateTime LastUpdated
        {
            get
            {
                return this.lastUpdatedField;
            }
            set
            {
                this.lastUpdatedField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SellingCodeID")]
        public ulong[] SellingCodeID
        {
            get
            {
                return this.sellingCodeIDField;
            }
            set
            {
                this.sellingCodeIDField = value;
            }
        }
        /// <remarks/>
        public uint ProductID
        {
            get
            {
                return this.productIDField;
            }
            set
            {
                this.productIDField = value;
            }
        }
    }
