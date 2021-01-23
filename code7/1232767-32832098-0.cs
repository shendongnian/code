    public class ProjectDescription : BaseEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
     
        [JsonProperty("key")]
        public string Key { get; set; }
     
        [JsonProperty("name")]
        public string Name { get; set; }
     
        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; } 
    }  
     
    public class AvatarUrls
    {
      [JsonProperty("32x32")]
      public string Size32 { get; set; }
             
      [JsonProperty("48x48")]
      public string Size48 { get; set; }
    }
