    public class SomeObject: INotifyPropertyChanged
    {
             public decimal AlertLevel {
                get {
                    return alertLevel;
                }
                set {
                    if(alertLevel == value) return;
                    alertLevel = value;
                    OnPropertyChanged("AlertLevel");
                }
    
              private void OnPropertyChanged(string propertyName) {
                if (PropertyChanged != null)
                    GUIThreadDispatcher.Instance.BeginInvoke(() => {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    });
            }}
