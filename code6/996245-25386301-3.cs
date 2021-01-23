    public class Customer : INotifyPropertyChanged {
        public string Name { get; set; }
        public string Address {
            get { return address; }
            set {
                address = value;
                if (thereArePropertyChangedEventSubcribers()) 
                    raisePropertyChangedEventFor("Address");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void raisePropertyChangedEventFor(string propertyName) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool thereArePropertyChangedEventSubcribers() { 
            return PropertyChanged != null; 
        }
        private string address;
    }
