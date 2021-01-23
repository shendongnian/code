    public class Current : ObservableObject
    {
            private string _status;
    
            public Current()
            {
                Status = "Not Connected";
            }
    
            public string Status
            {
                get { return _status; }
                set
                {
                    _status = value;
                    OnPropertyChanged(); // call this to update
                }
            }
    }
