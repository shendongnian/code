    public class UserData
    {
      public string id { get; set; }
      public string username { get; set; }
      public string password { get; set; }
      public string rank { get; set; }
    }
    // and then, in your code:
    List<UserData> userData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserData>>(result);
