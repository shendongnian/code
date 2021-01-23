        public class BaseObject
        {
            [JsonProperty(email_verified)]
            public bool EmailVerified { get; set; }
    	    [JsonProperty(app_metadata)]
            public AppMetadata AppMetadata { get; set; }
        }
    
        public class ExtendedObject : BaseObject
        {
    	   [JsonProperty(user_id)]
           public string UserId { get; set; }
        }
        
