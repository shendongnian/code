    public class ViewModel{
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged (string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null) {
                PropertyChanged (this, new PropertyChangedEventArgs (propertyName));    
            }
        }
    string info;
    int myInt = 0;
    public string Forename {
        get {
            return info;
        }
        set {
            if (myInt == 0) {
                info = value;
                OnPropertyChanged ("Forename");
            }
            else if (myInt == 1)
            {
                info = "TextTwo";
                OnPropertyChanged ("Forename");
            }
            else 
            {
                info = "TextThree";
                OnPropertyChanged ("Forename");
            }
        }
    }
    }
