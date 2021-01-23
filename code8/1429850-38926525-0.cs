    public class ProfileResponse
    {
        public string AVRRProfileId { get; set; }
        public string ESBTransactionGuId { get; set; }
        public string ErrorMessage { get; set; }
        public RegisteredOwners RegisteredOwners { get; set; }
        public Transaction Transaction { get; set; }
    }
    public class ProfileResponseWrapper 
    {
        [JsonProperty(Name = "getProfilesByImisidResponse")]
        public ProfilesByImisResponse response;
    }
    public class ProfilesByImisResponse
    {
        [JsonProperty(Name = "getProfilesByImisidResult")]
        public ProfilesByImisResult result;
    }
    public class ProfilesByImisResult
    {
        [JsonProperty(Name = "profileResponse")]
        public List<ProfileResponse> ProfileResponses;
    }
    public class RegisteredOwners
    {
        public List<RegisteredOwner> RegisteredOwner; //You should consider naming these differently as this isn't ideal for clarity
    }
