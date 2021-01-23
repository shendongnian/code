    public class MediaDetectionUser
    {
        public string Username { get; set; }
     
        //This JsonProperty helps reference the types during deserialization
        [JsonProperty("Roles", ItemTypeNameHandling = TypeNameHandling.All)]
        public ICollection<IMediaDetectionRole> Roles { get; set; }
        public MediaDetectionUser()
        {
            Roles = new List<IMediaDetectionRole>();
        }
    }
