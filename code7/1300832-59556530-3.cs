    using System.ComponentModel;
    using System.Runtime.Serialization;
    
    namespace Infragistics.Samples.Shared.Models
    {
        [DataContract]
        public abstract class ObservableModel : INotifyPropertyChanged 
        {
            protected ObservableModel()
            {
                IsPropertyNotifyActive = true;
            }
    
            #region INotifyPropertyChanged  
    
            public bool IsPropertyNotifyActive { get; set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
            
            protected bool HasPropertyChangedHandler()
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                return handler != null;
            }
            protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null && IsPropertyNotifyActive)
                    handler(sender, e);
            }
            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                OnPropertyChanged(this, e);
            }
            protected void OnPropertyChanged(object sender, string propertyName)
            {
                OnPropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
            protected virtual void OnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            protected delegate void PropertyChangedDelegate(object sender, string propertyName);
    
            #endregion
        }
    }
