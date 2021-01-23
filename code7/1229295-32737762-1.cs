    public class DragablePC : INotifyPropertyChanged
    {
        public DragablePC(PC_Infos pc, double x = 0d, double y = 0d)
        {
            _pcItem = pc;
            PcRow = y;
            PcColumn = x;
        }
        private double _x;
        public double PcColumn
        {
            get { return _x; }
            set
            {
                if (value == _x) return;
                _x = value;
                RaisePropertyChanged("PcColumn");
            }
        }
        private double _y;
        public double PcRow
        {
            get { return _y; }
            set
            {
                if (value == _y) return;
                _y = value;
                RaisePropertyChanged("PcRow");
            }
        }
        PC_Infos _pcItem;
        public DragablePC(PC_Infos pc, double x = 0d, double y = 0d)
        {
            _pcItem = pc;
            PcRow = y;
            PcColumn = x;
        }
        public override string ToString() { return _pcItem.PC_Name; }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
