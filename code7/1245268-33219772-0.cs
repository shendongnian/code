    public class YourViewModel : INotifyPropertyChanged
    {
        ...
        public event PropertyChangedEventHandler PropertyChanged;
        private DataView displayView;
        public DataView DisplayView
        {
            get { return displayView; }
            set 
            {    
                displayView = value;
                if (PropertyChanged != null)
                {                
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(DisplayView)));
                }
            }
        }
        ...
    }
