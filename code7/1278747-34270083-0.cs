    namespace Data.Databases 
    {
        [MetadataType(typeof(AddressMetadata))]
        public partial class Address : IAddress
        {
        }
        public class AddressMetadata 
        {
            public string Title { get; set; }
        }
    
        public interface IAddress
        {
            [Obsolete]
            public string Title { get; set; }
        }
    }
