    public class LoginModel : IData
    {
         [JsonProperty(PropertyName = "email")]
         public string Email {get;set;}
         [JsonProperty(PropertyName = "password")]
         public string Password {get;set;}
    }
