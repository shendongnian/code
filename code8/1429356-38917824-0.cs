    [JsonObject (MemberSerialization.OptIn)]
    public class UserDataDict : Dictionary<string, object>
    {
        [JsonProperty]
        public string userID { get; set; }
        [JsonProperty]
        public string emailAddress { get; set; }
        [JsonProperty]
        public string fullName { get; set; }
        [JsonProperty]
        public string accountType { get; set; }
        [JsonProperty]
        public string units { get; set; }
        [JsonProperty]
        public string unitsDistance { get; set; }
        [JsonProperty]
        public string newsletterSub { get; set; }
 
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string location { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string phoneNumber { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string address { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string photo { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string createdDate { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string verifyURL { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
        public string timezone { get; set; }
        [JsonProperty (NullValueHandling = NullValueHandling.Include)]
        public APIManifestDict apiManifest { get; set; }
    }
