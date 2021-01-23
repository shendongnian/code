    public class PPModel
    {
        private string _fieldOne;
        public string Property1
        {
            get { return _fieldOne; }
            set
            {
                _fieldOne = value;
                // update DB
            }
        }
        private int _field2;
        public int Property2
        {
            get { return _field2; }
            set
            {
                _field2 = value;
                // update DB
            }
        }
        // and so on for all properties
    }
