    class BukuAudio
    {
        private string _BundleName;
    
        public string MyProperty
        {
            get
            {
                if (_BundleName == null) return "";
    
                return _BundleName;
            }
            set { _BundleName = value; }
        }
    }
