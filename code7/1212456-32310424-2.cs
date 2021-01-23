    public class Data : INotifyPropertyChanged
    {
        private Visibility _visible;
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        //public Visibility Visible { get; set; }
        public Visibility Visible
        {
            get { return this._visible; }
            set
            {
                this._visible = value;
                RaisePropertyChanged("Visible");
            }
        }
        public Data(int _ID, string _Name,Visibility _visible)
        {
            ID = _ID;
            Name = _Name;
            Visible = _visible;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
