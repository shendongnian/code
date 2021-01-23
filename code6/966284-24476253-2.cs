    public class FrogGameData
    {
        private Frog _frog1;
        private Frog _frog2;
        
        [XmlElement(Order = 2)]
        public Frog Frog1
        {
            get { return _frog1; }
            set { _frog1 = value; }
        }
        [XmlElement(Order = 1)]
        public Frog Frog2
        {
            get { return _frog2; }
            set { _frog2 = value; }
        }
    }
