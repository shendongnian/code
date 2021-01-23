    public class buyer : BasePropertyChanged
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; }
        }
        private string _bname;
        public string bname
        {
            get { return _bname; }
            set { _bname = value; NotifyPropertyChanged("bname"); }
        }
        private int _buy_id;
        public int buy_id
        {
            get { return _buy_id; }
            set { _buy_id = value; NotifyPropertyChanged("buy_id"); }
        }
        private string _mobileno;
        public string mobileno
        {
            get { return _mobileno; }
            set { _mobileno = value; NotifyPropertyChanged("mobileno"); }
        }
    }
