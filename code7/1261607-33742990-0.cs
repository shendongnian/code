    public class MyData : INotifyPropertyChanged
    {
        private bool isChecked;
        public bool IsChecked 
        { 
            get { return isChecked; } 
            set
            {
               if (isChecked != value)
               {
                  isChecked = value;
                  OnPropertyChanged("IsChecked");
               }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
