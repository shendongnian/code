    public class CustomEventArgs : EventArgs {
        public string PropertyName { get; set; }
    };
    public class SubObservableObject {
        public delegate void CustomEventHandler(object sender, CustomEventArgs args);
        public event CustomEventHandler PropertyChanged;
        public string ChangedProperty {
            get { return _changedProperty; }
            set {
                PropertyChanged(this, 
                                new CustomEventArgs { PropertyName = "ChangedProperty" });
                _changedProperty = value;
            }
        }
        public string _changedProperty;
    };
