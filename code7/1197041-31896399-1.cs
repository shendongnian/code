    class Phone
    {
        public int ID { get; set; }
        private string _imei;
        public string IMEI 
        { 
            get { return _imei;}
            private set { _imei = Encrypt(value); }
        }
    }
