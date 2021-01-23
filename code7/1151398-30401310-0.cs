    public class Outer
    {
        public int Id { get; set; }
        public Guid? ProductFamilyId { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        Guid? OldProductFamilyId
        {
            get
            {
                return Convert(ProductFamilyId);
            }
        }
        private Guid? Convert(Guid? guid)
        {
            if (guid != null)
            {
                var bytes = guid.Value.ToByteArray();
                bytes[0] = unchecked((byte)~bytes[0]); // For example
                guid = new Guid(bytes);
            }
            return guid;
        }
    }
