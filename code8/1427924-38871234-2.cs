    public class state_master: XYZ
    {
        private country_master _cm;
    
        public country_master cm
        {
            get { return _cm; }
            set { _cm = value; }
        }
    
        public void state_method()
        {
            this.cm = new country_master();
            this.cm.country_name;
        }
    
    }
