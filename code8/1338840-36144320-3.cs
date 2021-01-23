         [JsonObject]
         public class Person
         {
           [JsonProperty("FirstName")]
           public string GivenName {get; set;}
    
           [JsonProperty("LastName")]
           public string FamilyName {get; set;}
      
           ... More Properties
         }
