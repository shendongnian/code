    public class MyViewModel
    {
        private bool _showWpa; 
        public bool ShowWpa
        {
            get
            {
                return _showWpa;
            }
            set
            {
                if (_showWpa != value)
                {
                    _showWpa = value;
                    NotifyPropertyChanged("ShowWpa");
                }
            }
        }
        //etc..
    }
