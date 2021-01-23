    public class AddressIndexModel
    {
        public AddressIndexModel()
        {
            this.Addresses = new List<Address>();
        }
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public List<Address> Addresses { get; set; }
    }
