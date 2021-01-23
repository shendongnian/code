    public class Model : INotifyPropertyChanged {
        private DayOfWeek dayOfWeek;
        public DayOfWeek DayOfWeek {
            get {
                return this.dayOfWeek;
            }
            set {
                if (this.dayOfWeek != value) {
                    this.dayOfWeek = value;
                    this.OnNotifyPropertyChanged("DayOfWeek");
                }
            }
        }
        private void OnNotifyPropertyChanged(string name) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
