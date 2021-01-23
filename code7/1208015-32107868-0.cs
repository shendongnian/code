    public class Customer
    {
        // other properties
 
        protected virtual Address MainAddress { get; set; }
        protected virtual Address ShipAddress { get; set; }
        protected virtual Address EnglishAddress { get; set; }
        private IEnumerable<Address> _addresses = null;
        public virtual IEnumerable<Address> Addresses
        { 
            get 
            {
                if (_addresses == null)
                {
                    MainAddress.AddressType = AddressType.Main;
                    ShipAddress.AddressType = AddressType.Ship;                                     
                    EnglishAddress.AddressType = AddressType.English;
                   _addresses = new[] { MainAddress, ShipAddress, EnglishAddress };
                }
                return _addresses;
            }
        }
    }
    
