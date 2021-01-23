    public class SubObservableObject : INotifyPropertyChanged {
        public string ChangedProperty {
            get { return _changedProperty; }
            set {
                PropertyChanged(this, new PropertyChangedEventArgs("ChangedProperty" ));
                _changedProperty = value;
            }
        }
        public string _changedProperty;
        public event PropertyChangedEventHandler PropertyChanged;
    };
