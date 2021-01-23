    public class MyClass
    {
        private string _StringFieldID;
        public long LongFieldID { set; get; }
        public string OtherField{set;get;}
        public string StringFieldID{
            set
            {
                _StringFieldID= value;
                LongFieldID= long.Parse(_StringFieldID);
            }
            get
            {
                return _StringFieldID;
            }
        }
    }
