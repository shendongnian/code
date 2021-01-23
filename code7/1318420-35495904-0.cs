    public class MyViewModel : INotifyPropertyChanged
    {
        //...
        private int myProperty = 0;
        public int MyProperty 
        {
            get { return myProperty; }
            set
            {
                myProperty = value;
                
                // Raise the property changed notification
                OnPropertyChanged("MyProperty");
            }
        }
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
