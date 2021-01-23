    public class UserProfile
    {
        [JsonProperty("fullname")]
        public string FullName { get; set; }
        [JsonProperty("imageid")]
        public int ImageId { get; set; }
        [JsonProperty("dob", NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<DateTime> DOB { get; set; }
    }
