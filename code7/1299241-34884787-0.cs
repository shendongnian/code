    public class CustomerModel
    {
        [DisplayName("Address")]
        public DetailAddress AddressDetails { get; set; }
        [DisplayName("Contact information")]
        public DetailContact ContactDetails { get; set; }
        [DisplayName("Personal information")]
        public DetailPersonal PersonalDetails { get; set; }
    }
