     [DataContract]
     public class Post
     {
        [JsonConverter(typeof(DictionaryWithSpecialEnumKeyConverter))]
        [DataMember(Name = "images")]
        public Dictionary<ImageResolution, Media> Images { get; set; }
     }
