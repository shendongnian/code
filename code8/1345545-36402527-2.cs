    namespace MyService.SAPNamespace {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://sap.com/....")]
    public partial class SAPClassRequestBundle : object, System.ComponentModel.INotifyPropertyChanged{
		private System.DateTime zTimeField;
        [System.Xml.Serialization.XmlIgnore] //This line is added so that its not used
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://sap.com/....", DataType="time", Order=106)]
        public System.DateTime ZTime {
            get {
                return this.zTimeField;
            }
            set {
                this.zTimeField = value;
                this.RaisePropertyChanged("ZTime");
            }
        }
	}
