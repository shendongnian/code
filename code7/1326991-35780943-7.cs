    public class ObjectProxy : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private object dataItem;
        private System.Reflection.PropertyInfo prop;
    
        private object val;
        public object Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    val = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    
        public ObjectProxy(object DataItem, string propertyName)
        {
            this.dataItem = DataItem;
            if (dataItem != null)
            {
                prop = dataItem.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    val = prop.GetValue(dataItem);
                }
            }
        }
    
        private void OnPropertyChanged(string name)
        {
            if (prop != null)
                prop.SetValue(dataItem, val);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
