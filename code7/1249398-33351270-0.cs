    [DataContract]
    public class Token
    {
      [DataMember(Name = "u")]
      public string UserName { get; set; }
      [DataMember(Name = "t")]
      public DateTime TimeStamp { get; set; }
      [DataMember(Name = "m")]
      public string Magic { get; set; }
      public Token()
      {
        Magic = MAGIC;
        TimeStamp = DateTime.Now;
      }
      public const string MAGIC = "SOME_RANDOM_STRING";
    }
   
    public class ImpersonateController : Controller
    {
      [HttpGet]
      public ActionResult Start(string encryptedToken)
      {
        // symmetric encryption - hopefully you know how to do it :)
        string decryptedToken = Decrypt(encryptedToken);
        var serializer = new DataContractJsonSerializer(typeof(Token));
        Token token;
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(decryptedToken)))
        {
          token = serializer.ReadObject(stream);
        }
        if (!string.Equals(token.Magic, Token.MAGIC) || 
          (DateTime.Now - token.TimeStap).TotalMinutes > 1))
        {
          // magic doesn't match or timestamp is too old
          throw new Exception("Invalid token.");
        }
        FormsAuthentication.SetAuthCookie(token.UserName, true);
        return new HttpStatusCodeResult(HttpStatusCode.OK); 
      }
    }
