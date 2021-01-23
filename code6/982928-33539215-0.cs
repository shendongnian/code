        public class Docs
        {
        [Key]
        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        }
