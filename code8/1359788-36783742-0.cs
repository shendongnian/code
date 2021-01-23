    public sealed class PersonMap : CsvClassMap<Person>
    {
        public PersonMap()
        {
            Map( m => m.Id );
            Map( m => m.Name );
            References<AddressMap>( m => m.Address );
        }
    }
    
    public sealed class AddressMap : CsvClassMap<Address>
    {
        public AddressMap()
        {
            Map( m => m.Street );
            Map( m => m.City );
            Map( m => m.State );
            Map( m => m.Zip );
        }
    }
