    public class Outer
    {
        public int Id { get; set; }
        [JsonConverter(typeof(InterfaceLabelConverter))]
        public Guid? ProductFamilyId { get; set; }
    }
