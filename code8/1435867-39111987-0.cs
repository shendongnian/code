    public class Address
    {
        private string _postalCode;
        public Address()
        {
            PostalCode = "";
        }
        public string PostalCode 
        { 
            get
            {
                //This will never return a null
                return _postalCode ?? "";
            }
            set
            {
                _postalCode = value;
            } 
        }
    }
