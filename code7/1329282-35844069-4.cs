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
