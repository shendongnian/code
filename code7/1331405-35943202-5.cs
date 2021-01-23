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
                      GUIThreadDispatcher.Instance.BeginInvoke(() => {
                         if (PropertyChanged != null)
                              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    });
            }}
