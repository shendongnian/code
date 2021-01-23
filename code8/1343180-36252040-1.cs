    public class MediaDTO : BaseEntityDTO
    {
        [JsonProperty(Required = Required.AllowNull)]
        public int Id { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public bool IsAlive { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string Description { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public PidDTO Pid { get; set; }
    }
    public class BaseEntityDTO
    {
        [JsonProperty(Required = Required.AllowNull)]
        public bool IsDeleted { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public DateTime AddedDate { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public DateTime UpdatedDate { get; set; }
    }
