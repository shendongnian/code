    namespace MyService.SAPNamespace {
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://sap.com/....")]
    public partial class SAPClassRequestBundle : object, System.ComponentModel.INotifyPropertyChanged {
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "ZTime", Namespace = "http://sap.com/....", DataType = "string", Order = 106)]
        public System.String ZTimeString {
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
    }
