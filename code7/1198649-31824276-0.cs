        public class LabelValuePair:INotifyPropertyChanged
    {
        public bool  RequiresTimeRefresh{get { return !string.IsNullOrEmpty(Label) && Label.ToLower() == "time"; }}
        private string label;
        public string Label
        {
            get { return label;}
            set { label = value; }
        }
        private string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; Notify("Value");}
        }
        public LabelValuePair(string label, string value)
        {
            this.Label = label;
            this.Value = value;
        }
        private void Notify(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
