    public class Fmi
    {
        [JsonProperty("@attributes")]
        public Attributes invalid_nameattribute { get; set; }
        public FmipLockStatusDevice fmipLockStatusDevice { get; set; }
    }
    public class FmipLockStatusDevice
    {
        [JsonProperty("@attributes")]
        public Attributes2 invalid_nameattribute2 { get; set; }
    }
