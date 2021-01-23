    public class PersonalInfo 
    {
        private ICollection<Address> _Addresses = new List<Address>()
    
        public int Id { get; set; }
        public string Name{ get; set; }
 
        public virtual ICollection<Address> Addresses 
        { 
           get { return _Addresses; }
           set { _Addresses = value}
    
        public int NumberOfAddresses
        { 
           get return Addresses.Count()
        }
    } 
