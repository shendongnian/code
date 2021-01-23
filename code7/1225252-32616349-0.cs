    public class Data : CommonBase
    {
        public Data()
        {
            getAtty();
        }
        private ObservableCollection<Attorneys> _AttyList;
        public ObservableCollection<Attorneys> AttyList
        {
            get { return _AttyList; }
            set
            {
                if(value != this._AttyList)
                {
                    _AttyList = value;
                    NotifyPropertyChanged("AttyList");
                }
            }
        }
        public void getAtty()
        {
            AttyList = new ObservableCollection<Attorneys>();
            using (var context = new Context())
            {
                AttyList = context.Attorney.ToList();
            }
        }
    }
