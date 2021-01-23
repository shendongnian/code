    public class MyVM
    {
        private string _status = "status1";
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if(_status!=value)
                {
                    _status =value
                    OnPropertyChanged("Status");
                }
            }
        }
    }
