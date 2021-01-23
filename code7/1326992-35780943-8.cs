    public class ObjectProxy : INotifyPropertyChanged, IDisposable
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
                if (!Object.Equals(val, value))
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
    
                    // Sync from dataItem to ObjectProxy
                    if (dataItem is INotifyPropertyChanged)
                    {
                        INotifyPropertyChanged pc = dataItem as INotifyPropertyChanged;
                        pc.PropertyChanged += DataItemPropertyChanged;
                    }
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
    
        // The source item changed - Update our Value
        private void DataItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (prop != null && e.PropertyName == prop.Name)
            {
                Value = prop.GetValue(dataItem);
            }
        }
    
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (dataItem is INotifyPropertyChanged)
                    {
                        var pc = dataItem as INotifyPropertyChanged;
                        pc.PropertyChanged -= DataItemPropertyChanged;
                    }
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
