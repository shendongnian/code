    namespace CoreProject.Persistence.EFCore
    {
        [ModelMetadataType(typeof(IUserMetadata))]
        public partial class User : IUserMetadata
        {
            public string FullName => FirstName + " " + LastName;
        }
    
        public interface IUserMetadata
        {
            [JsonProperty(PropertyName = "Id")]
            int UserId { get; set; }
    
            [JsonIgnore]
            string Password { get; set; }
            [JsonIgnore]
            string PasswordHashKey { get; set; }
            [JsonIgnore]
            byte Role { get; set; }
        }
    }
