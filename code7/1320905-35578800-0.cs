    class LearnerTelephones
    {
        public string ID { get; set; }
        public bool IsFirstPointOfContact { get; set; }
        public LocationType LocationType { get; set; }
        public string Notes { get; set; }
        public string TelephoneNumber { get; set; }
        public bool UseForTextMessages { get; set; }
    }
    class LocationType
    {
        public string ID { get; set; }
        public IList<NameType> NameType { get; set; }
    }
    class NameType
    {
        public string IDNAME { get; set; }
        public string IDAdd { get; set; }
    }
    class RootObject
    {
        public LearnerTelephones LearnerTelephones { get; set; }
    }
