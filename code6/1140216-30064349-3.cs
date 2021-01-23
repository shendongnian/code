    // Customer specific extension data for a phone number
    public class PhoneNumberExtension : IExtensionDataFor<PhoneNumber>
    {
        public string Prefix { get; set; }
    }
