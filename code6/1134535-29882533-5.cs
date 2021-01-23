    public class SubObservableObject : INotifyPropertyChanged {
        public string ChangedProperty {
            get { return _changedProperty; }
            set {
                _changedProperty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChangedProperty" ));
            }
        }
        public string _changedProperty;
        public event PropertyChangedEventHandler PropertyChanged;
    };
