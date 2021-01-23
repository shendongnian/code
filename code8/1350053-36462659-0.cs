    class Pdt : Base
    {
        /* 
            Other properties
        */
        
        private ObservableCollection<Pdt> _pdts;
        public ObservableCollection<Pdt> Pdts
        {
            get { return _pdts; }
            set { _pdts = value; }
        }
    }
