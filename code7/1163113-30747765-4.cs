    public class Template
    {
        private double _printWidth;
        private double _printHeight;
        /// <summary>
        /// Print width in inches
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute()]
        public double PrintWidth
        {
            get
            {
                return this._printWidth;
            }
            set
            {
                this._printWidth = value;
                this.RaisePropertyChanged("PrintWidth");
            }
        }
        [System.Xml.Serialization.XmlElementAttribute()]
        public double PrintHeight
        {
            get
            {
                return this._printHeight;
            }
            set
            {
                this._printHeight = value;
                this.RaisePropertyChanged("PrintHeight");
            }
        }
    }
