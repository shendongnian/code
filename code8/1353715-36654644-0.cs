    public class MediaDetectionUser
    {
        public int PartnerID { get; set; }
        public string Username { get; set; }
        public string FeedPartnerName { get; set; }        
        public ICollection<MediaDetectionBucket> Buckets { get; set; }
        //This JsonProperty helps reference the types during deserialization
        [JsonProperty("Roles", ItemTypeNameHandling = TypeNameHandling.All)]
        public ICollection<IMediaDetectionRole> Roles { get; set; }
        public MediaDetectionUser()
        {
            Buckets = new List<MediaDetectionBucket>();
            Roles = new List<IMediaDetectionRole>();
        }
    }
