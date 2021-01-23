    public class SimpleViewModel : INotifyPropertyChanged
    {
        private int myValue = 0;
        public int MyValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
