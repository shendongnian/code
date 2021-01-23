    public class obj
    {
        private string _cReseller;
        public string cReseller
        {
            get
            {
                return String.IsNullOrEmpty(_cReseller) ? "N/A" : _cReseller;
            }
            set
            {
                _cReseller = value;
            }
        }
    
        //...You can put the other two properties below
    }
