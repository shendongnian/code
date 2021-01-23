    public class UserInfo
    {
      public string Name { set; get; }
      public DateTime Datetime { set; get; }        
    }
    private IEnumerable<UserInfo> ParseDateOfBirth(string info)
    {
       var res= info.Split(';').Select(n => n.Split(','))
                  .Select(n => new UserInfo  { Name = n[0].Trim(), 
          Datetime = DateTime.ParseExact(n[1], "d/M/yyyy", CultureInfo.InvariantCulture) });
            
    }
