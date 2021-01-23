    public class PostalAddressMap 
        : ClassMap<PostalAddress>
    {
        public PostalAddressMap()
        {
            Table("tblPostalAddresses");
            Id(x => x.Id);
            Map(x => x.Address);
            Map(x => x.AddressType);
            
            References(x => x.Contact)
                .Class<Contact>()
                .Column("Owner");
    
        }
    }
