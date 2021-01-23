    // Example "core" class with extension data
    public class PhoneNumber : IExtendableOf<PhoneNumber>
    {
        public enum Kind { Internal, External }
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public Kind NumberKind { get; set; }
        public virtual IExtensionDataFor<PhoneNumber> ExtensionData { get; set; }
    }
