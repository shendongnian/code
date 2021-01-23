    public partial class SAPClassRequestBundle : object, System.ComponentModel.INotifyPropertyChanged 
    {
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "ZTime", Namespace = "http://sap.com/....", DataType = "string", Order = 107)]
    public System.String ZTimeString 
        {
            get
            {
                return this.zTimeField.ToString("HH:mm:ss");
            }
            set
            {
                this.zTimeField = System.DateTime.ParseExact(value, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                this.RaisePropertyChanged("ZTime");
            }
        }
        public bool ShouldSerializeZTime()
        {
            return false;
        }
    }
