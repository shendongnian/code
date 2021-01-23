    public class SomeObject : INotifyPropertyChanged
    {
        private readonly ISynchronizeInvoke invoker;
        public SomeObject(ISynchronizeInvoke invoker)
        {
            this.invoker = invoker;
        }
    
        public decimal AlertLevel
        {
            get { return alertLevel; }
            set
            {
                if (alertLevel == value) return;
                alertLevel = value;
                OnPropertyChanged("AlertLevel");
            }
        }
    
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.invoker.BeginInvoke((Action)(() =>
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName))), null);
    
            }
        }
    }
    
